module.exports = {
  darkMode: "class", // This enables class-based dark mode
  content: ["./Views/**/*.cshtml", "./wwwroot/js/**/*.js"],
  theme: {
    extend: {
      colors: {
        primary: "#022b3a",
        secondary: "#1f7a8c",
        accent: "#bfdbf7",
        "light-bg": "#f3f4f6",
        "text-gray": "#4b5563",
        "text-light": "#6b7280",
      },
    },
  },
  plugins: {
    tailwindcss: {},
    autoprefixer: {},
  },
};
