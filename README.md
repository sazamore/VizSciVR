# VizSciVR
Development of immersive stimuli for VR behavioral experiments

This repository contains scripts, assets and Unity builds for recreating visual science tools for VR. 
A detailed document description can be found below.

Last update: Nov 23, 2020

- **Assets folder** - contains prefabs and components for virtual arena (continually moving visual stimuli)
- **Scenes folder** - empty
- **Scripts folder** - contains scripts for named scenes
  - **Forest** - uses ForestGen.cs to generate a field of trees with variables determining field footprient, number of trees, and distance between trees. Trees are 5m to 1/2 inter-tree distance
  - **InfiniteTunnel** - uses pipe.cs and pipesystem.cs to generate a segement and append it to a growing Bezier curve, respectively. Uses player.cs and playerControl.cs to create a player and move the camera according to keystrikes, respectively.
- **Inverse Perimetry folder** - contains all scripts and prefabs for determining field of view using an animal's head, spheres at the eye positions, and an orbiting observer. 
  - cast.cs - casts rays at target eyes (hardcoded). saves data to file based on name of target (left eye, right eye, etc.)
  - orbit.cs - moves object around based on world coordinates (use the UVWorld360.blend prefab), while continually looking at the target object
  - AddInvertedMeshCollider.cs - (*obsolete*) if casting rays from inside the head prefab, this script will invert the surface such that ray collisions with the interior surface can be detected.
