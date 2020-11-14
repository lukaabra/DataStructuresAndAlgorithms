# Algorithms and Data Structures

## Algorithms

#### Sorting
Array sorting algorithms:
- Insertion sort
- Selection sort
- Quick sort
- Merge sort

## Data structures

#### Linked list
Linear data structure that does not store its elements at contiguous memory locations. The elements are linked using pointers.
Each element is a Node which has a value and is pointing to the next Node.

##### Advantages
- Dynamic size.
- Ease of insertion/deletion.

##### Disadvantages
- Random access is not allowed. **Elements are accessed sequentially.**
- Extra memory space is required for each pointer.
- Not cache friendly.

#### Heap
A container for objects that have keys. The canonical use is a fast way to do repeated minimum/maximum components.
Heaps are trees that are rooted, binary, and as complete as possible.
Heap property means that at every node x:
	key[x] <= all keys of x's children

##### Operations
- Insert
	- O(logn)
- Extract min/max
	- Remove an object in the heap with the minimum/maximum key value
	- O(logn)
