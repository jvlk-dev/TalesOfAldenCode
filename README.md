# Tales of Alden – 3D Action RPG
Graduation Project | SPŠE Ječná | Developed in Unity & C#
<img width="1415" height="207" alt="Logo" src="https://github.com/user-attachments/assets/3afd6d9d-4d0d-4484-b1ef-8bf65e1bb35a" />

## 📖 Overview
Tales of Alden is a single-player 3D Action RPG set in a fantasy world. This project was developed as my final graduation work at SPŠE Ječná. The goal was to create a complex system combining custom-coded mechanics, 3D assets modeled in Blender, and a hand-painted user interface.

Key Technical Highlights:
- Custom logic for combat, inventory, and skill systems.
- Implementation of advanced Unity features like NavMesh and EventSystems.
- Original 3D assets with baked textures.


# 🛠 Key Mechanics
## 1. Advanced Magic System (Skill Tree)
<img width="1322" height="764" alt="image" src="https://github.com/user-attachments/assets/4f48e632-cd14-497c-907a-1c1a76de1c8b" />

Inspired by games like V Rising, the game features a modular skill tree system.
Two Elemental Branches: Fire and Wind, each with 3 unique abilities.
Dynamic Loadout: Players have 3 slots to combine abilities freely.
Damage Logic: Damage is calculated based on a combination of base ability stats, elemental proficiency, and the player's core "Magic Strength" attribute.
Technical Implementation: Uses EventSystems and DragHandler for a smooth drag-and-drop UI experience.

## 2. Combat & AI
Collider-Based Combat: Attacks are synchronized with animations using Box Colliders and Tags to ensure precise hit registration.
Enemy AI: Enemies use NavMeshAgent for navigation, featuring player detection, chasing logic, and automated attack patterns when in range.

## 3. Inventory & Item Management
<img width="1023" height="595" alt="image" src="https://github.com/user-attachments/assets/659645fb-b23f-420f-92fa-f8a4d794effd" />



System Design: A grid-based inventory with dedicated slots for consumables (3x) and weapons (2x).
Visual Feedback: Weapons not currently in hand are visually stowed on the character's back.
Persistence: Includes basic logic for item collection and state management.

# 🎨 Asset Creation (Blender & UI)

## 3D Modeling


All 3D models were created from scratch in Blender:
Character Models: A fully sculpted skeleton (including high-detail skull sculpting).
Weaponry: Custom swords using Texture Baking from nodes to ensure high performance within Unity.
<img width="738" height="711" alt="image" src="https://github.com/user-attachments/assets/bc4b8c8d-c155-49da-852e-a1cbc46c91ae" />
<img width="228" height="293" alt="image" src="https://github.com/user-attachments/assets/583e9837-a693-4135-b57e-f7179c4376c2" />

<img width="214" height="758" alt="Swords3" src="https://github.com/user-attachments/assets/c606394c-688e-4a6e-98df-43dde70d73f0" />
<img width="214" height="758" alt="Swords2" src="https://github.com/user-attachments/assets/ba087a10-1a64-47f6-a1a5-5133750957e1" />
<img width="214" height="758" alt="Swords" src="https://github.com/user-attachments/assets/214d3959-ef7c-4e75-818b-779252344876" />


## User Interface
Hand-Painted Assets: Using a graphic tablet, I designed original icons, buttons, and UI frames.
UX Design: Focus on clear menus (Main Menu, Pause System, Quest Journal).
<img width="1508" height="1382" alt="TornadoIcon" src="https://github.com/user-attachments/assets/432c994e-e703-4d3e-841a-01171541111c" />
<img width="2000" height="2000" alt="InventoryBGfail" src="https://github.com/user-attachments/assets/364378b4-2a79-4ce8-b9dd-4c6be8162d3a" />

# 📂 Project Structure
To maintain a professional workflow and scalability, the project follows a strict organizational structure:
- /Scripts: All C# logic (Player controllers, AI, UI handlers).
- /Prefabs: Pre-configured game objects for efficient re-use.
- /Materials & Textures: Custom shaders and baked textures.
- /Models: Original .blend and .fbx exports.

# 📄 Documentation
The full technical documentation (in Czech), detailing the development process, algorithms, and design choices, is available here:
👉 View Full PDF Documentation

# License
Licensed under MIT license (LICENSE-MIT or https://opensource.org/licenses/MIT)
