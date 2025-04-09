# YUME: A Tale of Dreams and Nightmares

## A Tale of Dreams and Nightmares

**Team Members** : Harsh Kothari , Sujot Singh , Angel Ramirez
**Development Milestones** 
- [ ] Design Document - *3/05*
- [ ] Assignment 5 - *3/19*
- [ ] Assignment 6 - *3/08*
- [ ] Alpha Test
- [ ] Beta Test
- [ ] Final Relaease

## Important Links

* [Design Doc](https://docs.google.com/document/d/1oUz_rGOp-j2mK4EMN8bPvPtkQ5c6IyHkfQukfWm5tEM/edit?tab=t.0)
* [Task List](https://docs.google.com/spreadsheets/d/1taPDdcrC46CoKB_lu0br7GeofeiH4uXGav2GyW59KS0/edit?usp=sharing)
* [Bug Tacker](https://github.com/3xcess/CS426_Final_Project_YUME/issues)
* [Asset Source](https://github.com/3xcess/CS426_Final_Project_YUME/issues) *Disclaimer: All assets from the Unity Asset Store unless explicitly stated otherwise*
* Demo links: [A5 - Prototype](https://drive.google.com/file/d/1G2fVeOl_RhjjZwZXZWWt6ypcQ0Tr1-ds/view?usp=sharing) || [A6 - Mechanim](https://piazza.com/class/m3z7e8cjd2x2p5/post/112)

## A6 Update

### Minimum Requirements
- [ ] 3 Physics Constructs
- [ ] 3 Mecanim use cases
- [ ] 3 Forms of AI
- [ ] 3 Uses of Lights and Textures

### Additional tasks completed
- [ ] Added 3 unique scenes for each challenge faced by Pheo, each implementing a unique form of Physics construct, AI, and rigged Mecanims
- [ ] Started Adding textures to the challenge scenarios (*Challenge 3, as of now*)
- [ ] As per design document, introduced first level of verticality in the Dream World (Lower Level which aids Pheo)
- [ ] Completed the initial layout and design of the Dream world's lower level (*Scene: DW_LowerLevel*)
- [ ] Added Skyboxes where suitable skyboxes were found
- [ ] Started with the texturing/designing of the main scenes (*Nightmare world has more progress as of writing this*)
- [ ] Smoothed out the interaction between different scenes
- [ ] Finalized textures for future use
- [ ] Improved UI elements
- [ ] Added an early placeholder for a cutscene

### Towards the game vision

#### Aesthetics
***
Finding the assets for the Dream world is proving to be a challenge now, but we do believe we have some good resources on our hand. While this means our Dream world, the one we start in, is severely un-textured compared to the other scenes, we should be able to make quick progress prior to the alpha release on this aspect.  
The nightmare world has slowly but surely progressed towards the aesthetic requirements we have of it, and an initial but satisfactory version is playable in this release.  
Challenge 3 is the only challenge scenario we have been able to progress on so far aesthetically, but that is because our efforts were directed towards texturing other scenes. Regardless, we have a good plan going ahead for the scenes that still demand texturing.
DW_LowerLevel is an example of a scene that we have been able to finish to a degree where we would believe it to be aesthetically finalized barring some minor tweaks as needed down the line.
We still need to get better assets for our scene triggers and  Story Clues, which is to be priority for the next sprint.

#### Mecanim and AI
***
All 3 of us had the freedom to implement any form of adversarial AI in our challenge scenarios due to the very nature of YUME's design. 
Sujot and Harsh implemented two very different, custom implementations of Bayesian Networks (*as per the grad requirement*), while Angel leaned towards an FSM implementation during this development cycle.
This leads to the Challenge scenarios truly being unique, providing quite a variety of gameplay. The mechanims and physics constructs used in these scenes served to aid the AI in acheiving the intended vision we had for our challenges.
During our self-testing during this development cycle, we believe this has lead to an interesting experience that kept the player on their toes.

#### Scene Interactions
***
One major goal accomplished during A6 has been smoothing out the transitions between scenes and worlds, something at the very core of YUME.
we intend to make the scene interplay even better by making the transitions feel smooth or abrupt, as per the vision we have for the final game, by introducing visual similarities/differences to the various scenes which interact within the gameplay.

#### General Refinement
***
Smoothed out the gameplay loop, improved the HUD, and removed any noticed bugs.
