export function isSupported() {
    return document.fullscreenEnabled;
}

export function requestDocumentFullscreen() {
    document.documentElement.requestFullscreen();
}

export function requestElementFullscreen(elementId) {
    const ele = document.getElementById(elementId);
    if (ele) {
        ele.requestFullscreen();
    }
}

export function exitFullscreenRequest() {
    document.exitFullscreen();
}

export function toggleDocumentFullscreen() {
    if (!document.fullscreenElement) {
        document.documentElement.requestFullscreen();
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        }
    }
}