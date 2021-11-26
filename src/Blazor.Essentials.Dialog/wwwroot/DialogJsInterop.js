export function showPrompt(message, defaultValue) {
    if (message && defaultValue) {
        return prompt(message, defaultValue);
    } else if (message) {
        return prompt(message);
    } else {
        return prompt();
    }
}

export function showConfirm(message) {
    return confirm(message);
}
