$(document).ready(function () {
    // Show Register Form
    $('#show-register').on('click', function (e) {
        e.preventDefault();
        switchForm('register');
    });

    // Show Login Form
    $('#show-login').on('click', function (e) {
        e.preventDefault();
        switchForm('login');
    });

    function switchForm(toForm) {
        const loginForm = $('#login-form');
        const registerForm = $('#register-form');

        if (toForm === 'register') {
            // Slide login form left and fade out
            loginForm.removeClass('active').addClass('slide-out-left');

            // After animation, show register form sliding from right
            setTimeout(() => {
                registerForm.removeClass('slide-in-right').addClass('active');
            }, 300);
        } else {
            // Slide register form right and fade out
            registerForm.removeClass('active').addClass('slide-in-right');

            // After animation, show login form sliding from left
            setTimeout(() => {
                loginForm.removeClass('slide-out-left').addClass('active');
            }, 300);
        }
    }

    // Handle form submissions (prevent default for demo)
    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        alert('فرم ورود ارسال شد (دمو)');
        // Here you would normally make an AJAX call
    });

    $('#registerForm').on('submit', function (e) {
        e.preventDefault();
        alert('فرم ثبت نام ارسال شد (دمو)');
        // Here you would normally make an AJAX call
    });

    // Forgot password
    $('#forgot-password').on('click', function (e) {
        e.preventDefault();
        alert('لینک بازگردانی رمز عبور به ایمیل شما ارسال شد (دمو)');
    });
});

// change background
// In your main.js file
const images = [
    '/authtemplate/pics/authBg-1.webp',
    '/authtemplate/pics/authBg-2.webp',
    '/authtemplate/pics/authBg-3.webp',
    '/authtemplate/pics/authBg-4.webp'
];

// Function to get a random image from the array
function getRandomImage() {
    const randomIndex = Math.floor(Math.random() * images.length);
    return images[randomIndex];
}

// Function to set the random image as body background
function setRandomBackground() {
    const randomImage = getRandomImage();

    // Create an Image object to check if webp loads successfully
    const img = new Image();

    img.onload = function () {
        // Webp is supported, use it directly
        document.body.style.backgroundImage = `url('${randomImage}')`;
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'center';
        document.body.style.backgroundRepeat = 'no-repeat';
        document.body.style.backgroundAttachment = 'fixed';
    };

    img.onerror = function () {
        // If webp fails to load, try with fallback extensions or show error
        console.error('Failed to load webp image:', randomImage);

        // Try alternative extensions (if you have fallbacks)
        const fallbackImage = randomImage.replace('.webp', '.jpg') ||
            randomImage.replace('.webp', '.png');

        document.body.style.backgroundImage = `url('${fallbackImage}')`;
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'center';
        document.body.style.backgroundRepeat = 'no-repeat';
        document.body.style.backgroundAttachment = 'fixed';

        // Or use a solid color as fallback
        // document.body.style.backgroundColor = '#f0f0f0';
    };

    img.src = randomImage;
}

// Set random background when page loads
window.addEventListener('load', setRandomBackground);

// Optional: Check webp support first
function checkWebPSupport() {
    return new Promise((resolve) => {
        const webP = new Image();
        webP.src = 'data:image/webp;base64,UklGRjoAAABXRUJQVlA4IC4AAACyAgCdASoCAAIALmk0mk0iIiIiIgBoSygABc6WWgAA/veff/0PP8bA//LwYAAA';
        webP.onload = webP.onerror = function () {
            resolve(webP.height === 2);
        };
    });
}

// Modified version with webp support check
async function initializeBackground() {
    const isWebPSupported = await checkWebPSupport();

    if (!isWebPSupported) {
        console.log('WebP not supported by browser, using fallbacks...');

        // Convert webp paths to jpg/png if you have fallbacks
        const fallbackImages = images.map(img =>
            img.replace('.webp', '.jpg') || img.replace('.webp', '.png')
        );

        // Use fallback images array instead
        images.length = 0;
        images.push(...fallbackImages.filter(img => img));
    }

    setRandomBackground();
}

// Use this instead of window.addEventListener('load', setRandomBackground);
// window.addEventListener('load', initializeBackground);