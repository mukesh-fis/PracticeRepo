/********************************************************
 * This is the back out script to switch back to Momentum
 * Momentum Server for pushing the files.
 ********************************************************/

DECLARE
    
    PROCEDURE Back_To_Momentum(   p_DisbType            IN VARCHAR2,
                                  p_Run_Nbr             IN VARCHAR2,
                                  p_SRC_FILE            IN VARCHAR2,
                                  p_New_Dest_Path       IN VARCHAR2,
                                  p_Exisitng_DEST_FILE  IN VARCHAR2,
                                  p_NEW_DEST_FILE       IN VARCHAR2)
    IS
        v_Payauto_Ctm_Info_Seq_Nbr      PAYAUTO_CTM_INFO.PAYAUTO_CTM_INFO_SEQ_NBR%TYPE;
        v_FTP_PushTypeSeqNbr            PUSH_TYPE.PUSH_TYPE_SEQ_NBR%TYPE;
        v_CTM_Push_Type                 PUSH_TYPE.PUSH_TYPE_SEQ_NBR%TYPE;
        v_CTM_Info_Found                BOOLEAN := TRUE;
        
        v_Payauto_Pushmon_Info_Seq_Nbr  PAYAUTO_PUSHMON_INFO.PAYAUTO_PUSHMON_INFO_SEQ_NBR%TYPE;
        v_Pushmon_Info_Found            BOOLEAN := TRUE;
    BEGIN
    
        BEGIN
            SELECT PAYAUTO_CTM_INFO_SEQ_NBR, PUSH_TYPE_SEQ_NBR
              INTO v_Payauto_Ctm_Info_Seq_Nbr, v_CTM_Push_Type
            FROM PAYAUTO_CTM_INFO
            WHERE THIRD_PTY_DISB_TYPE = p_DisbType
            AND RUN_NBR = p_Run_Nbr;
        EXCEPTION 
            WHEN NO_DATA_FOUND THEN 
                v_CTM_Info_Found := FALSE;
                
            WHEN TOO_MANY_ROWS THEN
                DBMS_OUTPUT.PUT_Line('Too many Payauto CTM Info records are found for Disb Type['|| p_DisbType || 
                                     '] and run number [' || p_Run_Nbr || 
                                     ']. Please check the input and data in PAYAUTO_CTM_INFO table.');  
                raise TOO_MANY_ROWS;
        END;
    
        IF ( V_CTM_INFO_FOUND = TRUE ) 
        THEN
            
            -- Let's find the sequence number for SFTP push type
            SELECT PUSH_TYPE_SEQ_NBR 
              INTO v_FTP_PushTypeSeqNbr
            FROM PUSH_TYPE
            WHERE PUSH_TYPE = 'FTP';
            
            -- verify if the CTM record is already pointing to SFTP
            IF v_CTM_Push_Type <> v_FTP_PushTypeSeqNbr THEN
 
                -- Let's update the push type to SFTP
                UPDATE PAYAUTO_CTM_INFO 
                SET PUSH_TYPE_SEQ_NBR = v_FTP_PushTypeSeqNbr, -- push type seq nbr for 'SFTP'
                    PUSH_CONFIG_SECTION = 'CONFIG_FTP_01'  -- SFTP credentails to be used, which are stored in secure_config table
                WHERE PAYAUTO_CTM_INFO_SEQ_NBR = v_Payauto_Ctm_Info_Seq_Nbr;
                
                DBMS_OUTPUT.PUT_Line('Successfully updated the PAYAUTO_CTM_INFO record to FTP for Disb Type['|| 
                                      p_DisbType || '] and run number [' || p_Run_Nbr || ']'); 
            END IF;
            
            
            -- Let's find the Payauto Pushmon Info record for the given file change.
            BEGIN
                SELECT PAYAUTO_PUSHMON_INFO_SEQ_NBR
                  INTO v_Payauto_Pushmon_Info_Seq_Nbr
                FROM PAYAUTO_PUSHMON_INFO
                WHERE PAYAUTO_CTM_INFO_SEQ_NBR  = v_Payauto_Ctm_Info_Seq_Nbr
                AND UPPER(SOURCE_FILE_NAME)     = UPPER(p_SRC_FILE)
                AND UPPER(DEST_FILE_NAME)       = UPPER(p_Exisitng_DEST_FILE);
                
            EXCEPTION 
                WHEN NO_DATA_FOUND THEN
                    DBMS_OUTPUT.PUT_Line('NO Payauto Pushmon Info record found for Disb Type['|| 
                                  p_DisbType || '], run number [' || p_Run_Nbr || '],' ||
                                  ' Source File [' || p_SRC_FILE || '] and existing destination file name [' ||
                                  p_Exisitng_DEST_FILE || ']'); 
                    v_Pushmon_Info_Found := FALSE;
            END;
            
            IF ( V_PUSHMON_INFO_FOUND = TRUE ) 
            THEN
              
                -- Let's update the Destination Path nad new destination file name for MoveIT server.
                UPDATE PAYAUTO_PUSHMON_INFO 
                  SET DEST_PATH       = p_New_Dest_Path,
                      DEST_FILE_NAME  = p_NEW_DEST_FILE 
                WHERE PAYAUTO_PUSHMON_INFO_SEQ_NBR = v_Payauto_Pushmon_Info_Seq_Nbr;
              
                DBMS_OUTPUT.PUT_Line('Successfully updated the destination path [' || 
                                      p_New_Dest_Path || '] and destination file name [' ||
                                      p_NEW_DEST_FILE || '] in PushMon Info table for Disb Type['|| 
                                      p_DisbType || '] and run number [' || p_Run_Nbr || ']'); 
            ELSE
                DBMS_OUTPUT.PUT_Line('Dis Payauto CTM Info record found for Disb Type['|| 
                                  p_DisbType || '] and run number [' || p_Run_Nbr || ']');  
            END IF;
 
            Commit;
           
        ELSE     
            DBMS_OUTPUT.PUT_Line('NO Payauto CTM Info record found for Disb Type['|| 
                                  p_DisbType || '] and run number [' || p_Run_Nbr || ']');    
            
        END IF;

    END; 	--Back_To_Momentum

BEGIN

