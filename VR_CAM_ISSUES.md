# Issues with VR Camera height adjustment movement and more

This document outlines all possible factors contributing to VR camera movement issues in Unity, particularly lack of up/down movement when crouching and restricted movement when walking in VR. These issues will be further figured out and resolved in Sprint 4.

## 1. Known Issues
- **No Up/Down Movement on Crouch**: VR camera view does not adjust height when the user crouches.
- **Restricted Movement When Walking**: VR character/player only moves when controlled by the left controller’s analog stick and does not respond to natural walking.

---

## 2. Potential Factors

### VR Rig Configuration
   - **Camera Position**: `Main Camera` the placement within the rig may be incorrect.
   - **Tracking Settings**: Incorrect or incomplete setup for tracking height and movement.
   - **Camera Offset**: Misconfigured offset inside the XR Rig affecting position changes.

### Controller Input Configuration
   - **Input Mapping**: Incorrect or incomplete mapping for crouch, head movement, and analog stick movement.
   - **Input System Compatibility**: Potential conflicts between Unity’s legacy Input settings and the new Input System.

### Components on the Camera
   - **Pose Tracking Settings**: Possible incorrect settings for position and rotation tracking on `Tracked Pose Driver`.

### Device-Specific Settings
   - **VR Device Variability**: The differences in VR hardware tracking that may affect height or movement control in VR view.

### XR Toolkit Version Compatibility
   - **Unity Version**: Potential compatibility issues between Unity version and XR Toolkit.

## Additional Testing Factors
   - **Unity Console Errors**: Any errors in the Unity Console that may provide insight into missing components or conflicts.
   - **Hardware Tracking Settings**: Device-specific tracking settings that may need modified in the Unity project.

---

## 5. Reference Links
- **Unity Documentation**: [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest)
- **Unity Forum Discussions**: [VR Section on Unity Forums](https://forum.unity.com/forums/virtual-reality-vr.160/)
- **Device-Specific SDK Documentation** (e.g., Oculus, HTC Vive)

---

## 6. Possible temporary solution to look into
- **Idea**: Here is a video for reference that shows how to implement a jump function in VR by adding a C# Script source code. Perhaps, a similar C# Script can be implemented but for crouching for now.
- [Video URL](https://www.youtube.com/watch?v=Mfim9MlgYWY)

---

## 7. Note
- These are primarily just potential factors of what may be the causes of the VR camera view issue but no certainty that they are the issue but they will all be considered in the next Sprint.

---

## 8. More Documentation:
- **Google Drive**: [Google Drive URL link](https://docs.google.com/document/d/1x7yXrYe-nVQQlAkGM9PSfx0kizXvqsZOEEUWjNve7_o/edit?tab=t.0)