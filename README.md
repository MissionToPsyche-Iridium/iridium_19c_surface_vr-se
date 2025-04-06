# NASA Psyche Mission: Surface Data VR

## Table of Content
1. [Project Overview](#overview)
2. [Team Members](#team)
3. [Technology Used](#technology)
4. [Guide how to build the project](#build)
5. [Video of an application](#video)
6. [Quiz Guide](#quiz)


## Overview
The NASA Psyche Mission: Surface Data VR application provides an interactive and educational Virtual Reality (VR) experience, allowing users to explore Mars using real NASA data. Users can stand on Mars' surface, navigate its terrain, and learn key facts about Mars and the Psyche asteroid. The application also features a quiz game to test users' knowledge of Psyche Mission.

The application is a result of the Psyche Student Collaborations component of NASA’s Psyche Mission (https://psyche.asu.edu) and is created in partial fulfillment of Arizona State University Capstone Courses. 

 <img src="https://github.com/user-attachments/assets/7b77bea9-a8e2-4557-ad68-3ffee9b6bcd8" width="500" height="300"/>

 <img src="https://github.com/user-attachments/assets/1b8415a1-6bac-4f4a-acdc-8d3fdbf4d315" width="500" height="300"/>
 
 <img src="https://github.com/user-attachments/assets/61c0611a-a1ca-44be-8ece-2d861b3b9f85" width="500" height="300"/>

 <img src="https://github.com/user-attachments/assets/b73cac3e-fa8f-4ede-85cb-b481fa25f3fe" width="500" height="300"/>

## Team
Software engineering students responsible for developing this application: 
- Iuliia Orellana
- Jose Grijalva
- Estevan Perez
- Neisa Mattos

## Technology
### Frameworks & Libraries
Unity Engine (HDRP) – Used for rendering high-fidelity VR environments.  
XR Interaction Toolkit – For handling VR interactions and controller inputs.  
TextMeshPro – Used for improved text rendering in UI elements.  
### IDE & Development Tools
Unity Editor (Version 2022.3.50.f1) – Primary development environment.  
Visual Studio and Intellij– For writing and debugging C# scripts.  
GitHub – Version control system used by the team.  
### Programming Languages
C# – Used for scripting game mechanics, UI, and VR interactions.


## Build
.....

## Video
......

## Quiz
The Psyche Quiz is an interactive trivia game designed to test users' knowledge about NASA’s Psyche mission. The quiz presents a series of multiple-choice questions, tracks user scores, and displays a final score screen based on performance. The application supports a retry option, allowing users to restart the quiz after completing it.
### Game Flow:
- The user starts the quiz and is presented with a question.
- Each question has one correct answer and multiple incorrect answers.
- When an answer is selected, the button color changes, and the text indicator appears under the question:
  - Green and “Correct!” for correct answers
  - Red and “Wrong answer” for incorrect answers
- After answering, the user can proceed to the next question clicking “Next question” button.
- The quiz consists of five questions per session.
- Skipped question counts as incorrectly answered.
- Once all questions are answered, the score screen is displayed, showing performance feedback, and “Try again” button appears, allowing users to play again.

### Scripts Responsible for Quiz
Assets > Scripts > Quiz scripts:
- AnswerButton.cs (Handles the behavior of answer buttons in the quiz game and correct answers count.)
- NextQuestionButton.cs (Manages next question button and try again button setup. Manages the score canvas and resets the game.)
- QuestionData.cs (Defines a question structure using ScriptableObjects, that hold question string and a list of possible answers.)
- QuestionSetup.cs (Manages quiz questions and answer button setup. Randomly selects a question, assigns answers to buttons, and ensures correct answer placement.)   
Assets > Editor:
- TSVtoSO.cs (Utility class for converting a TSV (Tab-Separated Values) file into ScriptableObject assets for storing quiz questions).   
Each question is stored in SO (Scriptable Object) in Assets/Resources/Questions folder.

### How to Add Questions and Answers
1. Create a new TSV file. The easiest way to do so is to use Google sheets (create a new Google sheet file, add data, and save it as TSV).
2. The file should have the following format (one question per line, separated by tabs):   
QUESTION  |  CORRECT ANSWER  |  WRONG ANSWER 1  |  WRONG ANSWER 2  |  WRONG ANSWER 3
3. The correct answer always must be listed first, right after the question. It will be randomized by the script later.
4. Name the file Questions and place it in Assets > Editor > TSVs.
5. Generate Scriptable Objects:   
  a. Open Unity   
  b. In the top menu, go to Utilities > Generate Questions   
6. This will parse the TSV file and create/update Scriptable Object assets in Assets > Resources > Questions folder.
7. Once completed, the updated questions will be available in the quiz.

### How to Update Questions and Answers
There are two ways to update questions:
1. Go to Assets/Resources/Questions folder, locate the Question SO, and update the needed information there.
2. Update the TSV file (Assets > Editor > TSVs>Questions.tsv) and re generate the questions (in Unity editor’s the top menu, go to Utilities > Generate Questions)   

### How to Delete Questions   
Go to Assets/Resources/Questions folder, locate the Question SO, and delete it.  
