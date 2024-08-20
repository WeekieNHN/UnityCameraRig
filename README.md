# Installation
This requires the 

# How to Use
Use the camera to set near/far clipping planes, FOV, and the like. 

The camera needs to have a tag matching what's required by the recorder window

## Floating Rig
Add the camera Rig prefab to your scene.

Adding transforms under the 'Waypoints' object will add positions and rotations the camera will move to.

The Camera Holder component contains variables that control the time between waypoints, the curve the camera moves along, if we want to loop the positions, and if the camera is vertical.

## Pan-Around Camera
Enter the `ItemView` scene, you'll see a plane containing a target object, and a camera rig.

Add the subject of the pan-around as a child of the target object. You can change the distance and rotation speed on the `Camera Spin` component on the camera rig.

To change the height and camera angle, change the local position of the recorderCamera, as the rig is what will pan around the item.

### Item Switcher Component
If you want to swap between multiple objects, add them to the array of the `Item Switcher` component on the Target object. If the component is enabled the objects listed in the array will switch according to the duration variable.

# Todo (@Frank)
- [ ] Add Keybinds to start/stop/eased stop/reset the camera movement
- [ ] Add basic camera movements as functions
    - [ ] Zoom in/out
    - [ ] Pan left/right/up/down amounts
    - [ ] Dolly Zoom
    - [ ] Camera Shake, idle
    - [ ] Tilt up/down
- [ ] Focus Controls
    - [ ] Rack focus between 2 focal lenths