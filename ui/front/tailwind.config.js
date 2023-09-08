/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,svelte,ts}'],
  theme: {
    fontFamily: {
      'sans': ['Roboto', 'system-ui'],
      'serif': ['ui-serif', 'Georgia'],
      'mono': ['ui-monospace', 'SFMono-Regular'],
      'display': ['Oswald',],
      'body': ['"Open Sans"'],
    },
    extend: {
      gridTemplateColumns: {
        "18": "repeat(18, minmax(0, 1fr))",
        "20": "repeat(20, minmax(0, 1fr))",
        "21": "repeat(21, minmax(0, 1fr))",
        "22": "repeat(22, minmax(0, 1fr))"
      },
      gridTemplateRows: {
        "12": "repeat(12, minmax(0, 1fr))",
        "16": "repeat(16, minmax(0, 1fr))",
        "18": "repeat(18, minmax(0, 1fr))"

      }
    },
  },
  daisyui: {
    themes: [
      {
        mytheme: {

          "primary": "#23ba64",

          "secondary": "#77b6ff",

          "accent": "#81cfd3",

          "neutral": "#22273f",

          "base-100": "#2d363e",

          "info": "#a0bcee",

          "success": "#105c32",

          "warning": "#be800e",

          "error": "#f04251",
        },
        mythemelight: {
          "primary": "#e26cdb",

          "secondary": "#e5ce5e",

          "accent": "#1cbf55",

          "neutral": "#261c26",

          "base-100": "#f4f5f5",

          "info": "#7e97f1",

          "success": "#20d5b7",

          "warning": "#fbe16a",

          "error": "#f94e6d",
        },
        mytheme2: {

          "primary": "#57dbab",

          "secondary": "#f4b2ee",

          "accent": "#f7e096",

          "neutral": "#1f2a32",

          "base-100": "#d1d5db",

          "info": "#91dbee",

          "success": "#2ab296",

          "warning": "#f1b44b",

          "error": "#fc5566",
        },
        mytheme3: {

          "primary": "#129b5d",

          "secondary": "#e8a461",

          "accent": "#f79e99",

          "neutral": "#24213b",

          "base-100": "#e5e5eb",

          "info": "#1b84f3",

          "success": "#1f8e74",

          "warning": "#f8c754",

          "error": "#f75066",
        }, mytheme4: {

          "primary": "#1364a3",

          "secondary": "#f8f8f8",

          "accent": "#3a123e",

          "neutral": "#dddddd",

          "base-100": "#ffffff",

          "info": "#459ee3",

          "success": "#269852",

          "warning": "#efb72a",

          "error": "#e01e5a",
        },
      },
    ],
  },
  plugins: [require("daisyui")],
}

