let media = [];
let notificationHandler;

export function isMatched(query) {
    return window.matchMedia(query).matches;
}

export function isSupported() {
    return typeof window.matchMedia != "undefined" || typeof window.msMatchMedia != "undefined";
}

export async function observe(query, action) {
    if (media.filter((x) => x.media === query).length >= 1) {
        return;
    }

    notificationHandler = action;

    for (let index = 0; index < query.length; index++) {
        const mediaQueryList = window.matchMedia(query[index]);

        await handleMediaQueryEvent(mediaQueryList);
        mediaQueryList.onchange = handleMediaQueryEvent;

        media.push(mediaQueryList);
    }
}

export function dispose() {
    media.forEach((x) => (x.onchange = null));

    media = [];
}

async function handleMediaQueryEvent(event) {
    if (notificationHandler) {
        await notificationHandler.invokeMethodAsync('HandleMediaQueryValueChanged', { Matches: event.matches, Media: event.media.trim() });
    }
}