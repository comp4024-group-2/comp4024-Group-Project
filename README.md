# Project README

Welcome to our Git project! This README will guide you through the basics of using Git for version control. If you're new to Git, don't worry – we've included simple instructions to help you get started.

## Getting Started with Git

### Installation
If you haven't already installed Git, you can download and install it from [git-scm.com](https://git-scm.com/).

### Cloning the Repository
To get started, clone this repository to your local machine using the following command:

```bash
git clone https://github.com/comp4024-group-2/comp4024-Group-Project
```

### Basic Git Commands

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
If you are pushing a local branch for the first time, you will have to connect it 
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

### Workflow

1. Pull changes from th
