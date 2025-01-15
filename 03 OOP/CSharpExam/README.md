# C# Examination System

## Business Requirements

This project involves designing and implementing an Examination System for an organization based on the following specifications:

### 1. Question Object Design

-   A `Question` class should be designed to represent individual questions.
-   Each question includes:
    -   **Header**: The question header.
    -   **Body**: The main content of the question.
    -   **Mark**: The mark allocated to the question.

### 2. Exam Types

The system supports two types of exams:

-   **Final Exam**
-   **Practical Exam**

### 3. Question Types

The application must handle different types of questions for each exam type:

-   **Final Exam**:
    -   True or False
    -   Multiple Choice Questions (MCQ) (Choose one answer)
-   **Practical Exam**:
    -   Multiple Choice Questions (MCQ)

**Note**: A base `Question` class should be defined, with each specific question type inheriting from it.

### 4. Answer Class Design

-   Define an `Answer` class containing the following:
    -   `AnswerId`: Identifier for the answer.
    -   `AnswerText`: The text of the answer.
-   Each question is associated with an array of answers and the correct answer:
    -   `Answers[] AnswerList`: An array of possible answers for the question.

### 5. Base Exam Class

-   Define a base `Exam` class to describe common exam attributes:
    -   **Time**: The duration of the exam.
    -   **Number of Questions**: The total number of questions in the exam.
    -   **ShowExam Functionality**: This method will display exam details, with its implementation varying depending on the exam type.

### 6. Subject Association

-   Every exam is associated with a subject.
-   Define a `Subject` class with the following members:
    -   `SubjectId`: The identifier for the subject.
    -   `SubjectName`: The name of the subject.
    -   `Exam`: The exam associated with the subject.
-   Implement functionality to create an exam for a subject.

### 7. Exam Behavior

-   **Practical Exam**:
    -   Displays the correct answers after the exam is completed.
-   **Final Exam**:
    -   Displays the questions, answers, and grade upon completion.

### 8. Main Method Requirements

-   In the `Main` method, declare a `Subject` object and create an exam for it (either Final or Practical).

### 9. Additional Features

-   Implement the following in the system:
    -   **ICloneable**: To allow cloning of objects.
    -   **IComparable**: To compare objects.
    -   Override `ToString` for custom string representation of objects.
    -   Use **constructor chaining** where necessary to streamline object creation.
