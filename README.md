# iridium_19c_surface_vr-se

## Project Overview
The Surface Data VR project is a simulation software developed for NASA’s Psyche Mission. It allows users to explore planetary bodies in a 3D virtual environment, with compatibility for both Virtual Reality (VR) and desktop/laptop (non-VR) use. Users can select from various planetary bodies to experience, and learn more about them in an immersive and interactive way..


## Guideline for this project:
1. Branching Strategy:
  * Create new branches based on the user story you are working on.
  * Use descriptive branch names, e.g. US#23_TASK45
2. Commit Messages:
  * Always leave relevant messages for any commits or changes pushed to the repository.
  * Use concise yet meaningful messages, e.g., Added planet navigation 
   feature or Fixed crash in VR mode.
3. Pull Requests:
  * Every Pull Request (PR) must be reviewed by at least one other team 
    member before it can be approved and merged into the master branch.
  * Ensure that all tests pass before creating a PR.
  * Provide a clear description of the changes made and include references to 
    related GitHub Issues if applicable.
4. Bug Tracking:
  * If any bugs or mistakes are found in the source code, address them 
    through GitHub Issues to ensure quick resolution.
  * Assign the issue to a team member and use it to track the bug-fixing 
    process.
  * Always include the issue number in the related branch name and commit 
   message, e.g., bugfix/issue-123-fix-crash.
5. Unit Testing:
  * For each new feature implemented in the source code, provide unit testing 
    functions using Google Test in separate .cpp and header files.
  * Place all tests under the Tests directory, and ensure that they follow 
   the same naming conventions as the source files.
6. Documentation:
  * Create documentation for new feature implementations depending on the 
   complexity of the code.
  * Use the Docs folder to store documentation, and ensure that all major 
   components and systems have clear explanations.
7. Root Directory Management:
  * Avoid cluttering the root directory with unnecessary files.
  * Place assets, source code, and documentation in their respective folders 
    to maintain a clean and organized structure.
8. C# Practice Code:
 * For all tutorial-related C# practice code, create new branches for C# 
  practice/tutorial tasks.
 * NEVER merge these branches into the master branch. Use a separate branch
9. Code Style:
 * Follow consistent coding standards (e.g., naming conventions, indentation) 
   to ensure the codebase remains clean and readable.
 * Use descriptive names for variables, functions, and classes to make the 
   code self-explanatory.
10. Testing:
 * Write unit tests for every major feature, focusing on both edge cases and 
   regular use cases.
 * Make sure tests are passing before submitting any PR.
11. Feature Flags:
 * Use feature flags when implementing complex or experimental features, 
   allowing you to enable/disable them without impacting the rest of the 
   codebase.
12. README Updates:
  * Update this README.md file regularly to reflect changes in the project, 
    especially regarding new guidelines or rules.



## Guideline for handling large files that may be too large to be version-controlled on this repository
- `[Link to PDF file on Google Drive explaining the Guideline](https://drive.google.com/file/d/1rfryCKC70w-OKXNyA74vVn06OMWHd_mx/view?usp=drive_link)'
- `[Link to Jose's shared OneDrive](https://arizonastateu-my.sharepoint.com/my?id=%2Fpersonal%2Fjlgrijal%5Fsundevils%5Fasu%5Fedu%2FDocuments%2FASU%20SER%20Fall2024%2DSpring2025%20Capstone%20%2D%20Surface%20Data%20VR)'




## Helpful resources to follow as a starting template for Unity VR development:

- '[3-hour Unity VR tutorial YouTube video](https://www.youtube.com/watch?v=YBQ_ps6e71k)'
- '[Google Docs documentation with key takeaways on the Unity VR tutorial video](https://docs.google.com/document/d/17ar3QAVtqOynBui0f8brmMJu6dnFJ6QNbgSPhKmED3M/edit?tab=t.0)'
- '[Short video of Unity VR simulation of exploring planet Venus](https://www.youtube.com/watch?v=GOl91blT1n0)'
