# codility

C++ samples for codility lessons.

* GenomicRangeQuery
- problem: for all p-q range, looping over string so it make O(M*N) time which is bad
- solution: it seems prefix sum will solve it. for each "char" in S we will sum A-C-G-T values from 0 - N-1. So we can find range.
