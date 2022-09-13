compile: merge_sort.c
	gcc -o merge_sort merge_sort.c

test: test_merge_sort.cc
	cmake -S . -B build && \
	cmake --build build && \
	cd ./build && ctest