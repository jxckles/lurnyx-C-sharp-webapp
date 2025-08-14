export class LoadingScreen {
    static show() {
        const overlay = document.getElementById('loadingOverlay');
        if (overlay) {
            overlay.classList.remove('opacity-0', 'pointer-events-none');
            overlay.classList.add('opacity-100');
        }
    }

    static hide() {
        const overlay = document.getElementById('loadingOverlay');
        if (overlay) {
            overlay.classList.add('opacity-0', 'pointer-events-none');
            overlay.classList.remove('opacity-100');
        }
    }
}