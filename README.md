# Pixel Path

Welcome to our Unity game project! This README includes an intorudction to our project, as well as a simple guide for using Git.

- [Introduction](#introduction)
- [Using Git](#using-git)
  - [Getting Started with Git](#getting-started-with-git)
    - [Installation](#installation)
    - [Cloning the Repository](#cloning-the-repository)
  - [Workflow](#workflow)
  - [Git Standards](#git-standards)
    - [Commit Message Format](#commit-message-format)
    - [Example](#example)
    - [Guidelines](#guidelines)
  - [Other Basic Git Commands](#other-basic-git-commands)

<a name="introduction"></a>
## Introduction

Welcome to our Unity game for COMP4024! For this project, we aim to create a fun and interactive educational game, made for students between 11 to 14 years old.

This project is developed using Unity 2022.3.19f1, a stable and reliable version of the Unity game engine.

**Group 2 Team Members:**
  - Ivan Garrahan (psyig2@nottingham.ac.uk)
  - Justin Dreyer (psyjd8@nottingham.ac.uk)
  - Zeshippi (Yiping Xu) (psxyx17@nottingham.ac.uk)
  - Mahika Kapoor (psxmk7@nottingham.ac.uk)
  - Zhiyu Zhang (alyzz79@nottingham.ac.uk)

<!-- TOC --><a name="using-git"></a>
# Using Git

<!-- TOC --><a name="getting-started-with-git"></a>
## Getting Started with Git

<!-- TOC --><a name="installation"></a>
### Installation
If you haven't already installed Git, you can download and install it from [git-scm.com](https://git-scm.com/).

<!-- TOC --><a name="cloning-the-repository"></a>
### Cloning the Repository
To get started, clone this repository to your local machine using the following command:

```bash
git clone https://github.com/comp4024-group-2/comp4024-Group-Project
```


<!-- TOC --><a name="workflow"></a>
## Workflow

1. Pull changes from the remote repository before starting work:
```bash
git pull
```
2. After you have completed your changes, add them and commit them (this is explained further below). This prepares your code for pushing to the repository
```bash
git commit -am "docs: Appropriate commit message"
```
3. Always pull first before pushing! There may be new changes on the remote branch:
```bash
git pull
```
4. Now you can push to the upstream branch:
```bash
git push
```
All done! Your changes will be merged to the upstream branch

Here are some [other basic git commands](#other-basic-git-commands) to complete other activities

<!-- TOC --><a name="git-standards"></a>
## Git Standards

Establishing standards for Git commit messages is crucial for maintaining a clear and organized project history. Below are the basic guidelines for Git commit messages:

<!-- TOC --><a name="commit-message-format"></a>
### Commit Message Format

Each commit message should follow this format:

```
<Type>: <Description>

<Body>
```

- **Type**: Describes the type of change being made. It can be one of the following:
  - **feat**: A new feature
  - **fix**: A bug fix
  - **docs**: Documentation changes
  - **style**: Changes that do not affect the meaning of the code (whitespace, formatting, etc.)
  - **refactor**: Code changes that neither fix a bug nor add a feature
  - **test**: Adding or modifying tests
  - **chore**: Changes to the build process or auxiliary tools

- **Description**: A concise summary of the changes in present tense. It should not exceed 50 characters and should start with a lowercase letter.

- **Body**: A more detailed description of the changes. It should provide context, explain why the changes were made, and how they address the issue. This section should be wrapped at 72 characters per line.

<!-- TOC --><a name="example"></a>
### Example

```
git commit -am "feat: Add user authentication feature

Implement user authentication using JWT tokens for secure login and access control.

- Implemented login and registration endpoints
- Added middleware for token verification
- Updated user model to include password hashing

Closes #123"
```
- **Type**: feat indicates that a new feature is being added.
- **Description**: "Add user authentication feature" is a concise summary of the changes.
- **Body**: Provides detailed information about the changes, including implementation details and how they address the issue. Each line in the body is wrapped at 72 characters per line.
- **Closes #123:** This references the issue number (or pull request number) that this commit closes, providing context for the changes made.

<!-- TOC --><a name="guidelines"></a>
### Guidelines

- Use imperative mood in the subject line (e.g., "Add", "Fix", "Update").
- Keep the subject line short and descriptive.
- Use the body to provide more detailed information about the changes.
- Reference relevant issues or pull requests in the footer.
- Write meaningful commit messages that provide value to other developers and contributors.

<!-- TOC --><a name="other-basic-git-commands"></a>
## Other Basic Git Commands

Here are some basic Git commands to help you get started:

**Pulling Changes**: To get the latest changes from the remote repository, use:
```bash
git pull
```

**Committing Changes**: After making changes to files, you need to commit them to the repository.


You can use this command to both add and commit your files, which allows you to push them to the server.  
```bash
git commit -am "Descriptive message here"
```
If you want to only add changes, but not commit them, use this command:
```bash
git add .
```
And this is how to commit all added files:
```bash
git commit -m "Your descriptive commit message here"
```


**Pushing Changes**: To push your committed changes to the remote repository:
```bash
git push
```
**Checking Status**: To check the status of your working directory and staged changes:
```bash
git status
  ```

**Creating Branches**: To create a new branch and switch to it:
```bash
git checkout -b <branch-name>
```
**Switching Branches**: To switch to an existing branch:
```bash
git checkout <branch-name>
```

**Merging Branches**: To merge changes from one branch into another:
```bash
git checkout <branch-to-merge-into>
git merge <branch-to-merge-from>
  ```


