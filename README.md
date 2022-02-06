# LinearDialogueSystem
 A customizable linear dialogue system for Unity utilising state machines. 
 
 This system was developed to assist my second year project Retail Rush. 
 
# Features
- Multiple choice system utilising enums and state machines to dictate when the question is being asked and when the system is expecting a response.
- Each form of dialogue can be changed or manipulated to suit the requirements of the developer.
- Answers dictate the points given or deduted to the player which can be dynamically altered to suit the developer.
- Each NPC can have unique dialogue tailored to them.

## Multiple Choice Dialogue System
A custom dialogue manager and interaction system created from scratch to allow multiple variations of dialogue that could be retained in multiple prefabs with custom responses and accessibility for the developer to edit and change which answers they want to be correct. This system utilises game states to dictate the questionnnign system- for example, when the questioning state is active, coroutines are triggered to display the question and the notification, drawing the users eye to the question box. Once the routine is complete, the answering state is triggered, activating the answer boxes and the timer giving the user a specific amount of time to respond to the question (the timing to answer the question can be customised too). The user is required to answer the question by interacting with one of the four boxes but if the time reaches 0 before they can answer, the user is given the lowest possible score for that question and the coroutine loop begins in the questioning state again. With the versitility of this system, it allows developers to give each NPC their own unique clusters of dialogue.

![Screenshot_44](https://user-images.githubusercontent.com/43742155/152684807-79db4bc2-ea5b-49fa-bc27-cab43038a096.png)
![Screenshot_45](https://user-images.githubusercontent.com/43742155/152684808-bc665bb7-2510-44fa-a4ab-72765a41f406.png)

## Scoring System
As the plan for this system was to score users based on their questions, a scoring system was needed but needed to work in tandem with the dialogue system. This scoring system has direct access to the dialogue script in which the answers are given their maximum and minimum score value it can give. If the user selected the correct answer, the score manager will be given the scoring value for that question and display it on the screen.

![Screenshot_43_LI](https://user-images.githubusercontent.com/43742155/152684917-6aaecf62-ade7-4e0d-b9c5-285ca7b89dbc.jpg)
