window.openModal = (element) => {
    if (element && element.showModal) {
        element.showModal();  // ÷ffnet das Modal (native API)
    }
};

window.closeModal = (element) => {
    if (element && element.close) {
        element.close();  // Schlieﬂt das Modal
    }
};