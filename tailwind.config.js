/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Views/**/*.{cshtml,razor}", "./wwwroot/js/**/*.js"],
    theme: {
        extend: {
            screens: {
                sm: "576px",
                md: "768px",
                lg: "992px",
                xl: "1200px",
                "2xl": "1400px",
            },
            colors: {
                "primary": "#0077cc",
                "MainColor":"#1E1F2C"
            }
        },
    },
    plugins: [],
}

