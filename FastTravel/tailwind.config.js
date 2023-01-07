/** @type {import('tailwindcss').Config} */
module.exports = {
    content:
    [
        './Views/**/*.cshtml'
    ],
    theme:
    {
        extend: 
        {
            colors:
            {
                'mint': '#00ff90',
            },
            dropShadow:
            {
                'lg': '0 4px 4px rgba(0, 255, 144, 0.1)',
                'xl': '0 5px 5px rgba(0, 255, 144, 0.3)',
                '2xl': '0 25px 25px rgba(0, 255, 144, 0.15)',
            },
        },
    },
    plugins: [
    ],
}
