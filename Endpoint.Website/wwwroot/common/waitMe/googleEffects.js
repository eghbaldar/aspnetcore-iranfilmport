// Simplified Google-style loading
const GoogleLoader = {
    init() {
        // Create bar if not exists
        if (!document.getElementById('google-loader-bar')) {
            const bar = document.createElement('div');
            bar.id = 'google-loader-bar';
            bar.innerHTML = '<div class="google-loader-progress"></div>';
            bar.style.cssText = `
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 3px;
                background: #f1f1f1;
                z-index: 9999;
                display: none;
            `;

            const progress = bar.querySelector('.google-loader-progress');
            progress.style.cssText = `
                height: 100%;
                width: 0;
                background: #FFC312;
                transition: width 0.3s;
            `;

            document.body.appendChild(bar);
        }
    },

    start() {
        this.init();
        const bar = document.getElementById('google-loader-bar');
        const progress = bar.querySelector('.google-loader-progress');

        bar.style.display = 'block';
        document.body.style.opacity = '0.95';
        document.body.style.pointerEvents = 'none';

        // Animate
        let width = 0;
        const animate = () => {
            width += 10;
            if (width <= 90) {
                progress.style.width = width + '%';
                setTimeout(animate, 200);
            }
        };
        animate();

        bar.dataset.animation = 'true';
    },

    finish() {
        const bar = document.getElementById('google-loader-bar');
        if (!bar) return;

        const progress = bar.querySelector('.google-loader-progress');
        progress.style.width = '100%';

        setTimeout(() => {
            bar.style.display = 'none';
            document.body.style.opacity = '1';
            document.body.style.pointerEvents = 'auto';
            progress.style.width = '0';
        }, 300);
    }
};