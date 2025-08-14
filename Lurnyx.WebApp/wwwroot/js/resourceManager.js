// Configuration for each resource type
const RESOURCE_TYPES = {
  presentation: {
    accept: ".ppt,.pptx",
    description: "PPT, PPTX files up to 5MB",
    uploadText: "Upload Presentation",
    icon: '<img src="/img/trainingmaterials_img/ppt-icon.svg" alt="PPT" class="h-8 w-8 mb-3" />',
    previewIcon:
      '<img src="/img/trainingmaterials_img/ppt-icon.svg" alt="PPT" class="h-5 w-5" />',
    bgPreviewIcon: "bg-[#fc4b4d]/10",
    sizeLabel: "Slide Count",
  },
  pdf: {
    accept: ".pdf",
    description: "PDF files up to 5MB",
    uploadText: "Upload PDF",
    icon: '<img src="/img/trainingmaterials_img/pdf-icon.svg" alt="PDF" class="h-8 w-8 mb-3" />',
    previewIcon:
      '<img src="/img/trainingmaterials_img/pdf-icon.svg" alt="PDF" class="h-5 w-5" />',
    bgPreviewIcon: "bg-[#fc4b4d]/10",
    sizeLabel: "Page Count",
  },
  youtube: {
    accept: "", // No file upload for YouTube - we'll use URL input
    description: "YouTube video links",
    uploadText: "Add YouTube Video",
    icon: '<img src="/img/trainingmaterials_img/video-link-icon.svg" alt="YouTube" class="h-8 w-8 mb-3" />',
    previewIcon:
      '<img src="/img/trainingmaterials_img/video-link-icon.svg" alt="YouTube" class="h-5 w-5" />',
    bgPreviewIcon: "bg-[#7370ff]/10",
    sizeLabel: "Duration (minutes)",
  },
  video: {
    accept: "video/mp4, video/quicktime",
    description: "MP4, MOV files up to 10MB",
    uploadText: "Upload Video",
    icon: '<i class="fa-solid fa-video text-2xl mb-3"></i>',
    previewIcon: '<i class="fa-solid fa-video text-xl text-[#7370ff]"></i>',
    bgPreviewIcon: "bg-[#7370ff]/10",
    sizeLabel: "Duration (minutes)",
  },
};

class ResourceManager {
  constructor() {
    this.uploadedFiles = {
      presentation: [],
      pdf: [],
      youtube: [],
      video: [],
    };
    this.currentType = "presentation";
    this.resourceCounts = {
      presentation: 0,
      pdf: 0,
      youtube: 0,
      video: 0,
    };
    this.MAX_RESOURCES = 5;

    this.initEventListeners();
  }

  initEventListeners() {
    // View resource buttons
    document.addEventListener("click", (e) => {
      if (e.target.closest(".resource-view-btn")) {
        const file = e.target.closest(".resource-view-btn").dataset.file;
        this.viewResource(file);
      }

      if (e.target.closest(".resource-download-btn")) {
        const file = e.target.closest(".resource-download-btn").dataset.file;
        this.downloadResource(file);
      }
    });
  }

  viewResource(filename) {
    console.log(`Viewing resource: ${filename}`);
    // Special handling for YouTube videos
    if (filename.includes("youtube.com") || filename.includes("youtu.be")) {
      this.openYouTubeModal(filename);
    } else {
      // Temporary logic
      window.open(
        `/resources/view?file=${encodeURIComponent(filename)}`,
        "_blank"
      );
    }
  }

  openYouTubeModal(url) {
    // Extract video ID from URL
    const videoId = this.extractYouTubeId(url);
    if (!videoId) return;

    const modalHtml = `
            <div class="fixed inset-0 backdrop-blur-xs z-40">
                <div class="bg-white rounded-lg w-full max-w-4xl p-4">
                    <div class="flex justify-between items-center mb-4">
                        <h3 class="text-lg font-bold">YouTube Video</h3>
                        <button onclick="document.getElementById('youtubeModal').remove()" class="text-gray-500 hover:text-gray-700">
                            <i class="fa-solid fa-xmark"></i>
                        </button>
                    </div>
                    <div class="aspect-w-16 aspect-h-9">
                        <iframe width="100%" height="450" src="https://www.youtube.com/embed/${videoId}" 
                            frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
                            allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        `;

    const modal = document.createElement("div");
    modal.id = "youtubeModal";
    modal.innerHTML = modalHtml;
    document.body.appendChild(modal);
  }

  extractYouTubeId(url) {
    // Regex for extracting YouTube video ID from various URL formats
    const regExp =
      /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|&v=)([^#&?]*).*/;
    const match = url.match(regExp);
    return match && match[2].length === 11 ? match[2] : null;
  }

  downloadResource(filename) {
    console.log(`Downloading resource: ${filename}`);
    // For YouTube videos, this might not be applicable
    if (filename.includes("youtube.com") || filename.includes("youtu.be")) {
      alert("Please visit YouTube to download this video");
      return;
    }
    // For other files
    window.location.href = `/resources/download?file=${encodeURIComponent(
      filename
    )}`;
  }

  setResourceType(type) {
    this.currentType = type;
    this.updateTypeButtons();
    this.updateUploadAreas();
  }

  updateTypeButtons() {
    document.querySelectorAll(".resource-type-btn").forEach((btn) => {
      const isActive = btn.dataset.type === this.currentType;
      btn.classList.toggle("bg-white", isActive);
      btn.classList.toggle("text-black", isActive);
      btn.classList.toggle("text-black/50", !isActive);
    });
  }

  addResource() {
    if (this.resourceCounts[this.currentType] >= this.MAX_RESOURCES) return;

    this.resourceCounts[this.currentType]++;
    this.updateUploadAreas();
    this.addSizeInput(this.resourceCounts[this.currentType]);
  }

  removeResource(index) {
    this.resourceCounts[this.currentType]--;
    document.getElementById(`sizeField_${this.currentType}_${index}`)?.remove();
    document.getElementById(`previewContainer_${index}`)?.remove();

    if (
      this.uploadedFiles[this.currentType] &&
      this.uploadedFiles[this.currentType][index - 1]
    ) {
      this.uploadedFiles[this.currentType].splice(index - 1, 1);
    }

    this.updateUploadAreas();
  }

  updateUploadAreas() {
    const container = document.getElementById("resourceUploadContainer");
    if (!container) return;

    const config = RESOURCE_TYPES[this.currentType];
    container.innerHTML = "";

    for (let i = 1; i <= this.resourceCounts[this.currentType]; i++) {
      const areaHTML =
        this.currentType === "youtube"
          ? this.createYouTubeUploadAreaHTML(config, i)
          : this.createUploadAreaHTML(config, i);

      const tempDiv = document.createElement("div");
      tempDiv.innerHTML = areaHTML;
      container.appendChild(tempDiv);

      if (
        this.uploadedFiles[this.currentType] &&
        this.uploadedFiles[this.currentType][i - 1]
      ) {
        const uploadArea = document.getElementById(
          `uploadArea-${this.currentType}-${i}`
        );
        const previewContainer = document.getElementById(
          `previewContainer_${i}`
        );

        if (uploadArea && previewContainer) {
          uploadArea.classList.add("hidden");
          this.previewFile(
            {
              name: this.uploadedFiles[this.currentType][i - 1].name,
              size: this.uploadedFiles[this.currentType][i - 1].size,
            },
            i
          );
          previewContainer.classList.remove("hidden");
        }
      }
    }

    let sumCurrentResourceCount = 0;
    for (const type in this.resourceCounts) {
      sumCurrentResourceCount += this.resourceCounts[type];
    }

    if (sumCurrentResourceCount < this.MAX_RESOURCES) {
      const addButtonHTML = this.createAddButtonHTML();
      const tempDiv = document.createElement("div");
      tempDiv.innerHTML = addButtonHTML;
      container.appendChild(tempDiv);
    }
  }

  createUploadAreaHTML(config, index) {
    return `
            <div id="generalArea-${this.currentType}-${index}" class="resource-upload-area border border-gray-300 rounded-lg p-4 mb-4" data-resource-index="${index}">
                <div id="uploadArea-${this.currentType}-${index}" class="flex flex-col items-center justify-center border-2 border-dashed border-gray-300 rounded-lg p-6">
                    ${config.icon}
                    <div class="flex items-center">
                        <label for="ResourceFile_${index}" class="cursor-pointer">
                            <span class="px-4 py-2 border border-[#022B3A] text-[#022B3A] font-semibold rounded-lg hover:bg-[#022B3A]/10 transition-colors">
                                ${config.uploadText} #${index}
                            </span>
                            <input type="file" id="ResourceFile_${index}" name="ResourceFiles" class="sr-only" 
                                   accept="${config.accept}" onchange="resourceManager.previewFile(this, ${index})">
                        </label>
                    </div>
                    <p class="mt-2 text-xs text-gray-500">${config.description}</p>
                    
                    <button type="button" onclick="resourceManager.removeResource(${index})" 
                            class="mt-2 text-sm text-red-600 hover:text-red-800">
                        Remove
                    </button>
                </div>
                <div id="previewContainer_${index}" class="hidden w-full mt-4"></div>
            </div>
        `;
  }

  createYouTubeUploadAreaHTML(config, index) {
    return `
            <div id="generalArea-${this.currentType}-${index}" class="resource-upload-area border border-gray-300 rounded-lg p-4 mb-4" data-resource-index="${index}">
                <div id="uploadArea-${this.currentType}-${index}" class="flex flex-col items-center justify-center border-2 border-dashed border-gray-300 rounded-lg p-6">
                    ${config.icon}
                    <div class="w-full">
                        <div class="mb-3">
                            <label class="block text-sm font-medium text-gray-700 mb-1">YouTube Video URL</label>
                            <input type="url" id="youtubeUrl_${index}" 
                                class="block w-full rounded-lg bg-white py-2 px-3 text-base text-gray-900 placeholder:text-gray-400 border border-gray-300 focus:border-[#022B3A] focus:ring-2 focus:ring-[#022B3A]/20"
                                placeholder="https://www.youtube.com/watch?v=...">
                        </div>
                        <div class="mb-3">
                            <label class="block text-sm font-medium text-gray-700 mb-1">Video Title</label>
                            <input type="text" id="youtubeTitle_${index}" 
                                class="block w-full rounded-lg bg-white py-2 px-3 text-base text-gray-900 placeholder:text-gray-400 border border-gray-300 focus:border-[#022B3A] focus:ring-2 focus:ring-[#022B3A]/20"
                                placeholder="Video Title">
                        </div>
                        <div class="flex justify-center gap-2">
                            <button type="button" onclick="resourceManager.addYouTubeVideo(${index})" 
                                class="px-4 py-2 bg-[#022B3A] text-white font-semibold rounded-lg hover:bg-[#022B3A]/90 transition-colors">
                                Add Video
                            </button>
                            <button type="button" onclick="resourceManager.removeResource(${index})" 
                                class="px-4 py-2 text-sm text-red-600 hover:text-red-800">
                                Cancel
                            </button>
                        </div>
                    </div>
                </div>
                <div id="previewContainer_${index}" class="hidden w-full mt-4"></div>
            </div>
        `;
  }

  addYouTubeVideo(index) {
    const urlInput = document.getElementById(`youtubeUrl_${index}`);
    const titleInput = document.getElementById(`youtubeTitle_${index}`);

    if (!urlInput.value || !titleInput.value) {
      alert("Please provide both URL and title");
      return;
    }

    const videoId = this.extractYouTubeId(urlInput.value);
    if (!videoId) {
      alert("Please enter a valid YouTube URL");
      return;
    }

    const uploadArea = document.getElementById(
      `uploadArea-${this.currentType}-${index}`
    );
    const previewContainer = document.getElementById(
      `previewContainer_${index}`
    );

    if (uploadArea) uploadArea.classList.add("hidden");
    if (previewContainer) {
      previewContainer.classList.remove("hidden");
      previewContainer.innerHTML = `
                <div class="flex items-center border border-gray-200 rounded-lg p-3">
                    <div class="w-10 h-12 ${RESOURCE_TYPES.youtube.bgPreviewIcon} rounded flex items-center justify-center mr-3">
                        ${RESOURCE_TYPES.youtube.previewIcon}
                    </div>
                    <div class="flex-1">
                        <p class="text-sm font-medium">${titleInput.value}</p>
                        <p class="text-xs text-gray-500">YouTube Video</p>
                    </div>
                    <div class="flex gap-2">
                        <button type="button" class="text-gray-500 hover:text-gray-700 resource-view-btn" data-file="${urlInput.value}">
                            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                            </svg>
                        </button>
                        <button class="text-gray-500 hover:text-gray-700" onclick="resourceManager.removeResource(${index})">
                            <i class="fa-solid fa-xmark w-4 h-4"></i>
                        </button>
                    </div>
                </div>
            `;
    }

    this.uploadedFiles.youtube.push({
      name: titleInput.value,
      url: urlInput.value,
      size: "YouTube Video",
    });
  }

  createAddButtonHTML() {
    const typeName =
      this.currentType === "youtube"
        ? "YouTube Video"
        : this.currentType === "pdf"
        ? "PDF Document"
        : this.currentType.charAt(0).toUpperCase() + this.currentType.slice(1);

    return `
            <button type="button" onclick="resourceManager.addResource()" class="w-full py-2 text-[#022B3A] font-medium hover:bg-[#022B3A]/10 rounded-lg transition-colors add-another-button">
                + Add Another ${typeName}
            </button>
        `;
  }

  addSizeInput(index) {
    const container = document.getElementById("sizeLabel");
    const config = RESOURCE_TYPES[this.currentType];
    const newDiv = document.createElement("div");
    newDiv.id = `sizeField_${this.currentType}_${index}`;

    // Skip size input for YouTube videos
    if (this.currentType === "youtube") return;

    newDiv.innerHTML = `
            <div id="sizeField_${
              this.currentType
            }_${index}" class="flex items-center space-x-4">
                <div class="flex-1">
                    <label class="block text-sm font-medium text-gray-700 mb-1">
                        ${this.getTypeDisplayName()} #${index} ${
      config.sizeLabel
    }
                    </label>
                    <input type="number" name="resource_sizes[]"
                        class="block w-full rounded-lg bg-white py-2 px-3 text-base text-gray-900 placeholder:text-gray-400 border border-gray-300 focus:border-[#022B3A] focus:ring-2 focus:ring-[#022B3A]/20"
                        placeholder="Enter ${config.sizeLabel.toLowerCase()}">
                </div>
            </div>
        `;
    container.appendChild(newDiv);
  }

  getTypeDisplayName() {
    switch (this.currentType) {
      case "presentation":
        return "Presentation";
      case "pdf":
        return "PDF Document";
      case "youtube":
        return "YouTube Video";
      case "video":
        return "Short Video";
      default:
        return this.currentType;
    }
  }

  previewFile(source, index) {
    const isFileInput = source instanceof HTMLInputElement;
    const file = isFileInput ? source.files[0] : source;

    const name = isFileInput ? file.name : source.name;
    const size = isFileInput
      ? (file.size / (1024 * 1024)).toFixed(1)
      : source.size;

    if (!name) return;

    const uploadArea = document.getElementById(
      `uploadArea-${this.currentType}-${index}`
    );
    const previewContainer = document.getElementById(
      `previewContainer_${index}`
    );

    if (!previewContainer) return;

    if (uploadArea) {
      uploadArea.classList.add("hidden");
    }

    previewContainer.classList =
      "flex items-center border border-gray-200 rounded-lg p-3";
    previewContainer.innerHTML = `
            <div class="w-10 h-12 ${
              RESOURCE_TYPES[this.currentType].bgPreviewIcon
            } rounded flex items-center justify-center mr-3 my-auto">
                ${RESOURCE_TYPES[this.currentType].previewIcon}
            </div>
            <div class="flex-1">
                <p class="text-sm font-medium">${name}</p>
                <p class="text-xs text-gray-500">${size} MB</p>
            </div>
            <div class="flex gap-2">
                <button type="button" class="text-gray-500 hover:text-gray-700 resource-view-btn" data-file="${name}">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                    </svg>
                </button>
                <button type="button" class="text-gray-500 hover:text-gray-700 resource-download-btn" data-file="${name}">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4" />
                    </svg>
                </button>
                <button class="text-gray-500 hover:text-gray-700" onclick="resourceManager.removeResource(${index})">
                    <i class="fa-solid fa-xmark w-4 h-4"></i>
                </button>
            </div>
        `;

    previewContainer.classList.remove("hidden");

    if (isFileInput && file) {
      this.uploadedFiles[this.currentType].push({
        name: name,
        size: size,
      });
    }
  }

  previewExistingFileFile(source, index) {
    const isFileInput = source instanceof HTMLInputElement;
    const file = source;

    const name = source.name;
    const size = source.size;

    if (!name) return;

    const previewContainer = document.getElementById(`uploadedResourcesList`);
    const newPreviewContainer = document.createElement("div");

    if (!previewContainer) return;

    newPreviewContainer.classList =
      "flex items-center border border-gray-200 rounded-lg p-3";
    newPreviewContainer.innerHTML = `
            <div class="w-10 h-12 ${
              RESOURCE_TYPES[source.type].bgPreviewIcon
            } rounded flex items-center justify-center mr-3 my-auto">
                ${RESOURCE_TYPES[source.type].previewIcon}
            </div>
            <div class="flex-1">
                <p class="text-sm font-medium">${name}</p>
                <p class="text-xs text-gray-500">${size} MB</p>
            </div>
            <div class="flex gap-2">
                <button type="button" class="text-gray-500 hover:text-gray-700 resource-view-btn" data-file="${name}">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                    </svg>
                </button>
                <button type="button" class="text-gray-500 hover:text-gray-700 resource-download-btn" data-file="${name}">
                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4" />
                    </svg>
                </button>
                <button class="text-gray-500 hover:text-gray-700" onclick="resourceManager.removeResource(${index})">
                    <i class="fa-solid fa-xmark w-4 h-4"></i>
                </button>
            </div>
        `;

    previewContainer.classList.remove("hidden");
    previewContainer.appendChild(newPreviewContainer);
  }
}

// Initialize the resource manager
const resourceManager = new ResourceManager();
