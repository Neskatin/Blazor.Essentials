export function isSupported() {
    return typeof window.localStorage !== "undefined";
}

export function setItem(key, item) {
    localStorage.setItem(key, JSON.stringify(item));
}

export function getItem(key) {
    return JSON.parse(localStorage.getItem(key));
}

export function removeItem(key) {
    localStorage.removeItem(key);
}

export function clear() {
    localStorage.clear();
}