export function isSupported() {
    return typeof window.sessionStorage !== "undefined";
}

export function setItem(key, item) {
    sessionStorage.setItem(key, JSON.stringify(item));
}

export function getItem(key) {
    return JSON.parse(sessionStorage.getItem(key));
}

export function removeItem(key) {
    sessionStorage.removeItem(key);
}

export function clear() {
    sessionStorage.clear();
}
