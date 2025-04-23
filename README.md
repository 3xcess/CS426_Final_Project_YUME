# YUME: A Tale of Dreams and Nightmares

## A Tale of Dreams and Nightmares

**Team Members** : Harsh Kothari , Sujot Singh , Angel Ramirez
**Development Milestones** 
- [x] Design Document - *3/05*
- [x] Assignment 5 - *3/19*
- [x] Assignment 6 - *3/08*
- [x] Alpha Test
- [x] Beta Test
- [x] Final Relaease

## Important Links

* [Design Doc](https://docs.google.com/document/d/1oUz_rGOp-j2mK4EMN8bPvPtkQ5c6IyHkfQukfWm5tEM/edit?tab=t.0)
* [Task List](https://docs.google.com/spreadsheets/d/1taPDdcrC46CoKB_lu0br7GeofeiH4uXGav2GyW59KS0/edit?usp=sharing)
* [Bug Tacker](https://github.com/3xcess/CS426_Final_Project_YUME/issues)
* [Asset Source](https://github.com/3xcess/CS426_Final_Project_YUME/issues) *Disclaimer: All assets from the Unity Asset Store unless explicitly stated otherwise*
* Demo links: [A5 - Prototype](https://drive.google.com/file/d/1G2fVeOl_RhjjZwZXZWWt6ypcQ0Tr1-ds/view?usp=sharing) || [A6 - Mechanim](https://drive.google.com/file/d/1UvRbP1LN4cGhyywO9277SMsX0y2rRVLi/view?usp=drive_link)

## Dev Notes from the Team:
* #### As of A7 update, the output folder had large files that couldn't be uploaded to github. As a result, to run the game please extract the zipped files in the YUME_Data folder before launching the game. Thank you!
* ##### For some reason, in the A8 build there may be a persisting PlayerPerfs file that is downloaded with the main branch. This will make it so that the player persistence seems broken in the Dream World. To Fix this, try moving the output folder outside the root directory of where the git project is located on your system. If this doesn't work, you will unfortunately need to build the output again OUTSIDE the root directory of this project's downloaded git repo.

***

## A6 Update

### Minimum Requirements
- [x] 3 Physics Constructs
- [x] 3 Mecanim use cases
- [x] 3 Forms of AI
- [x] 3 Uses of Lights and Textures

### Additional tasks completed
- [x] Added 3 unique scenes for each challenge faced by Pheo, each implementing a unique form of Physics construct, AI, and rigged Mecanims
- [x] Started Adding textures to the challenge scenarios (*Challenge 3, as of now*)
- [x] As per design document, introduced first level of verticality in the Dream World (Lower Level which aids Pheo)
- [x] Completed the initial layout and design of the Dream world's lower level (*Scene: DW_LowerLevel*)
- [x] Added Skyboxes where suitable skyboxes were found
- [x] Started with the texturing/designing of the main scenes (*Nightmare world has more progress as of writing this*)
- [x] Smoothed out the interaction between different scenes
- [x] Finalized textures for future use
- [x] Improved UI elements
- [x] Added an early placeholder for a cutscene
- [ ] Improve Story Clues
- [ ] Select Player Character

### Specifics

#### Sujot:
* Custom Implementation of a Bayesian network for decision making of the Hidden enemies in Challenge 1(Green enemies which are slower than normal)
* Breakable Glass Physics Construct in Challenge 1
* Mecanim implemented for the Enemies in Challenge 1
* Lighting and textures implemented in DW_LowerLevel scene

#### Angel:
* Hostile NPC AI using Finite State Machines in Challenge 2
* Mecanim implpemented in Challenge 2 as the NPC enemy character
* Throwable object Physics Construct in Challenge 2
* Lighting and textures implemented in Nightmare scene

#### Harsh:
* Custom Implementation of a Bayesian network for decision making of the Hidden enemies in Challenge 3 (Green enemies which are slower than normal)
* Mecanim implpemented in Challenge 3 as the monster defending the exit
* Physics construct in the form of particle system that gets activated when the AI correctly predicts your move
* Lighting, textures, and skyboxes implemented in Challenge 3 and the Dreams scene

### Towards the game vision

#### Aesthetics
Finding the assets for the Dream world is proving to be a challenge now, but we do believe we have some good resources on our hand. While this means our Dream world, the one we start in, is severely un-textured compared to the other scenes, we should be able to make quick progress prior to the alpha release on this aspect.  
The nightmare world has slowly but surely progressed towards the aesthetic requirements we have of it, and an initial but satisfactory version is playable in this release.  
Challenge 3 is the only challenge scenario we have been able to progress on so far aesthetically, but that is because our efforts were directed towards texturing other scenes. Regardless, we have a good plan going ahead for the scenes that still demand texturing.
DW_LowerLevel is an example of a scene that we have been able to finish to a degree where we would believe it to be aesthetically finalized barring some minor tweaks as needed down the line.
We still need to get better assets for our scene triggers and  Story Clues, which is to be priority for the next sprint.

The Biggest task left unaccomplished during A6 has been us not being able to decide on our player models. 

#### Mecanim and AI
All 3 of us had the freedom to implement any form of adversarial AI in our challenge scenarios due to the very nature of YUME's design. 
Sujot and Harsh implemented two very different, custom implementations of Bayesian Networks (*as per the grad requirement*), while Angel leaned towards an FSM implementation during this development cycle.
This leads to the Challenge scenarios truly being unique, providing quite a variety of gameplay. The mechanims and physics constructs used in these scenes served to aid the AI in acheiving the intended vision we had for our challenges.
During our self-testing during this development cycle, we believe this has lead to an interesting experience that kept the player on their toes.

#### Scene Interactions
One major goal accomplished during A6 has been smoothing out the transitions between scenes and worlds, something at the very core of YUME.
we intend to make the scene interplay even better by making the transitions feel smooth or abrupt, as per the vision we have for the final game, by introducing visual similarities/differences to the various scenes which interact within the gameplay.

#### General Refinement
Smoothed out the gameplay loop, improved the HUD, and removed any noticed bugs.

***

## A7 Update

### Minimum Requirements
- [x] Updated the Game UI
- [x] Added Sounds to the Game
- [x] Finished the Challenge Scenarios
- [x] Updated the worlds of the different scenes and added player models + mecanims
- [x] Updated and extended the gameplay loop
- [x] Fixed bugs

### Specifics

#### Sujot's notes
* Finalized Challenge 1
* Updated the Story Clue UI (Pickup/Interact Prompt and Story Clue prefab model)
* Updated UI: Challenge 1 (World layout/textures/time pickups), DW_LowerLevel (Health Resource/Portal back to Dreams scene)
* Added Sounds: Challenge 1 (Background Theme, Ambient & Trigger based effects, Time Pick Up), DW_LowerLevel (Background)
* Updated World Lyout and Textures: Challenge 1, Dreams
* Fixed Bugs

#### Angels's notes
* Finalized Challenge 2
* Added Player mecanim + models for every scene
* Updated/Fixed the player movement
* Updated the Story Clue UI (Pickup/Interact Prompt and Story Clue prefab model)
* Updated UI: Challenge 2 (World textures, Enemy Health Bar), DW_LowerLevel (Health Resource/Portal back to Dreams scene)
* Added Sounds: Story Clues (Pick Up), Challenge 2 (Background)
* Fixed Bugs

#### Harsh's notes
* Finalized Challenge 3
* Added new UI:  Cutscenes for Challenges + Intro
* Updated UI: Challenge 3 (World layout/textures/Wrong move)
* Updated UI: Fixed bugged UI from A6
* Added Sounds: Challenge 3 (Background Theme, Wrong Move), Dreams (Background), Intro Screen (Background)
* Fixed Bugs

#### UI Changes
* Cutscenes + Intro Added for most scenes
* Interactions UI updated
* Level design + Textures Added to every scene
* Updated Player models
* TODO: Fix Bugged/Missing UI, Make UI more consistent across scenes
* Alpha Testing Feedback: Add more information in the UI elements for the player

#### Sound Changes
* Added background theme for most scenes
* Added Interaction sounds wherever applicable
* Added Ambient Sounds in some places
* TODO: Flesh out the soundscape more, make sounds more coherent, add sounds to Nightmare
* Alpha Testing Feedback: Sounds selection is generally good, Some sounds are missing, some are jarring, need to bring headphones for Beta Test.

#### General Refinement
* Fixed Bugs
* Smoothed out the Gameplay loop to better flow as intended
* Refined the aesthetics more

***

## A8 Update

#### Feedback from Alpha we worked on:
* Instructions/controls explained
* Varying spawn points 
* Fix died for character challenge 2 
* Portals need to be indicated or highlighted NW
* Indication of what needs to be collected 
* Scale makes player prefab seem faster(DW) over slower (NW)
* General bugs
* Glow or more attention to clues and chests
* Add dialog/text to how our game works

#### Assignment 8 Specific Tasks:
* UI Changes - Game End/Game Over
* Sound Changes  - Nightmare Background
* Add Shaders
* Update Intro Screen
* Add End Credits
* Fix Clipping bugs - DW
* Fix Clipping bugs - Lower Level
* Fix Clipping bugs - Nightmare
* Fix World Switch Bug
* Fix Time Over Limit Bug
* Add Info - Challenges
* Add Info - Player Guide
* Refine Challenge 1
* Refine Challenge 2
* Refine Challenge 3
* Update Design Doc

#### TODO List Remaining:
* Story
* jump doesn't work yet as intended
* Add more info 
* Add more text

#### Additional Features We are aiming for:
* Increasing the map size/adding more Clue content.
