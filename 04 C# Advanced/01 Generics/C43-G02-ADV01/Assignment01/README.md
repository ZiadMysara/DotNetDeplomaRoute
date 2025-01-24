# Assignment 1  

## Overview  
This assignment consists of multiple programming tasks related to sorting algorithms, generic classes, list manipulations, and string operations. The objective is to implement efficient solutions while adhering to best coding practices.  

## Tasks  

### 1. Optimizing the Bubble Sort Algorithm  
The Bubble Sort algorithm has a time complexity of **O(n²)** in its worst and average cases, making it inefficient for large datasets. Your task is to:  
- Optimize the **Bubble Sort** algorithm to improve its efficiency.  
- Implement the optimized **Bubble Sort** algorithm in code.  

---

### 2. Implementing a Generic `Range<T>` Class  
Create a generic class `Range<T>` that represents a range of values between a **minimum** and **maximum** value. The class should support basic operations like checking if a value is within the range and determining its length.  

#### **Requirements**  
- Create a generic class named `Range<T>`, where `T` represents the type of values.  
- Implement a **constructor** that takes the minimum and maximum values to define the range.  
- Implement a method **`IsInRange(T value)`** that returns `true` if the given value is within the range, otherwise `false`.  
- Implement a method **`Length()`** that returns the length of the range (difference between the maximum and minimum values).  
- **Note**: Assume that `T` implements the **`IComparable<T>`** interface to allow comparisons.  

---

### 3. Reversing an `ArrayList` In-Place  
You are given an `ArrayList` containing a sequence of elements. Implement a function that:  
- Reverses the order of elements in the same `ArrayList`.  
- Does **not** use the built-in `Reverse` method.  
- Modifies the existing `ArrayList` instead of creating a new one.  

---

### 4. Filtering Even Numbers from a List  
You are given a **list of integers**. Implement a function that:  
- Finds and returns a **new list** containing only the **even numbers** from the given list.  

---

### 5. Implementing a Custom `FixedSizeList<T>` Class  
Create a custom list **`FixedSizeList<T>`** with a predetermined capacity. This list should:  
- **Restrict** the number of elements added to its fixed capacity.  
- **Throw clear error messages** if an attempt is made to exceed the capacity or access invalid indices.  

#### **Requirements**  
- Create a generic class **`FixedSizeList<T>`**.  
- Implement a **constructor** that takes the fixed capacity of the list as a parameter.  
- Implement an **`Add`** method that adds an element to the list but **throws an exception** if the list is already full.  
- Implement a **`Get`** method that retrieves an element at a specific index but **throws an exception** for invalid indices.  

---

### 6. Finding the First Non-Repeated Character in a String  
Given a string, implement a function that:  
- Finds the **first non-repeated character** and returns its **index**.  
- If no such character exists, return `-1`.  
- **Hint**: You can use a **dictionary** to track character frequencies.  

---

## Notes  
- Ensure that all implementations follow **best coding practices** and use **efficient algorithms** where applicable.  
- **Exception handling** should be incorporated where necessary.  
- **Code readability** and **proper documentation** are essential.  
