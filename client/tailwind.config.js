/** @type {import('tailwindcss').Config} */
export default {
    content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
    theme: {
        extend: {
            colors: {
                'theme-gunmetal': '#1e1f29',
                'theme-eerie-black': '#15161d',
                'theme-crimson': '#e02b4a',
                'theme-lightcrimson': '#de4761',
                'theme-white': '#fff',
                'theme-lightblue': '#8D99AE',
                'theme-gray': '#e4e7ed',
                'theme-darkblue': '#2B2D42',
                'theme-blue': '#494c66',
                'theme-darkgray': '#333333'
            },
            fontFamily: {
                Montserrat: ['Montserrat', 'sans-serif']
            },
            fontSize: {
                xm: '0.85rem',
                '2xm': '0.90rem'
            },
            height: {
                100: '26rem'
            }
        }
    },
    plugins: []
};
