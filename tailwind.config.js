/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{razor,html,cshtml,cshtml.cs}"],
  theme: {
    extend: {
      fontFamily: {
        'lato': ["Lato", 'sans-serif'],
      },
    },
  },
  plugins: [],
};


