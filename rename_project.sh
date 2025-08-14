#!/bin/bash

# A script to refactor the project name from ASI.Basecode to Lurnyx.
# Run this from the root 'lurnyx' directory.

# 0. Safety Check
if [ ! -d "ASI.Basecode.WebApp" ]; then
    echo "ERROR: Could not find the 'ASI.Basecode.WebApp' directory."
    echo "Please make sure you are running this script from the root 'lurnyx' project directory."
    exit 1
fi

echo "This script will permanently rename your projects from 'ASI.Basecode' to 'Lurnyx'."
read -p "It's wise to have a backup or use git. Continue? (y/n) " -n 1 -r
echo
if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    echo "Operation cancelled."
    exit 1
fi

# 1. Clean the project with git
echo "--> Cleaning the project directory to remove build artifacts..."
echo "    This will remove all untracked files and directories (like bin/ and obj/)."
git clean -fdx
if [ $? -ne 0 ]; then
    echo "WARNING: 'git clean' command failed. This might happen if this is not a git repository."
    echo "Proceeding, but old folders might be left behind."
fi


# 2. Rename Directories and Project Files
echo "--> Renaming project directories and files..."
for dir in ASI.Basecode.*; do
  # Create the new name by replacing the prefix
  new_name=$(echo "$dir" | sed 's/ASI.Basecode/Lurnyx/')
  
  echo "    - Renaming directory '$dir' to '$new_name'"
  mv -- "$dir" "$new_name"

  # Rename the .csproj file inside the newly named directory
  if [ -f "$new_name/$dir.csproj" ]; then
    echo "    - Renaming .csproj for '$new_name'"
    mv -- "$new_name/$dir.csproj" "$new_name/$new_name.csproj"
  fi
done

# 3. Rename Solution File (if one exists)
if [ -f "ASI.Basecode.sln" ]; then
    echo "--> Renaming solution file..."
    mv ASI.Basecode.sln Lurnyx.sln
fi

# 4. Rename Specific C# Files (like DbContext)
echo "--> Renaming specific C# files..."
for file_path in $(find . -type f -name "AsiBasecode*.cs"); do
    dir_name=$(dirname "$file_path")
    file_name=$(basename "$file_path")
    new_file_name=$(echo "$file_name" | sed 's/AsiBasecode/Lurnyx/')
    echo "    - Renaming file '$file_name' to '$new_file_name'"
    mv -- "$file_path" "$dir_name/$new_file_name"
done

# 5. Find and Replace Namespaces and References
echo "--> Updating namespaces and references inside all project files..."

# Find all relevant text files, excluding git, bin, obj, and lib folders
files_to_update=$(find . -type f \( \
    -name "*.cs" -o \
    -name "*.csproj" -o \
    -name "*.sln" -o \
    -name "*.json" -o \
    -name "*.cshtml" \
    \) -not -path "./.git/*" \
       -not -path "*/bin/*" \
       -not -path "*/obj/*" \
       -not -path "*/wwwroot/lib/*")

# Use sed to replace the string in-place for all found files
for file in $files_to_update
do
  # Replace the all-caps version for namespaces and projects
  sed -i 's/ASI.Basecode/Lurnyx/g' "$file"
  # Replace the PascalCase version for class names
  sed -i 's/AsiBasecode/Lurnyx/g' "$file"
done
echo "    - Text replacement complete."

# 6. Clean Project Artifacts
echo "--> Cleaning newly named project artifacts..."
dotnet clean

echo ""
echo "-------------------------------------"
echo "Refactoring complete!"
echo "Please review the changes with 'git status' if you are using git."
echo "Your next step should be to run 'dotnet restore'."
echo "-------------------------------------"

