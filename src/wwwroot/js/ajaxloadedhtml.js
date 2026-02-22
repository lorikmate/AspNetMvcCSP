const getNonce = () => $('meta[name="csp-nonce"]').attr('content');

const injectNonce = (html, nonce) => {
    if (typeof nonce === undefined || nonce?.length <= 0 || typeof html === undefined || html?.length <= 0) return "";

    const domParser = new DOMParser();
    const dom = domParser.parseFromString(html, 'text/html');

    $(dom).find('script').each(function () {
        $(this).attr('nonce', nonce);
    });

    return dom.body.innerHTML;
};

const initPage = () => {
    $.get('/Home/AJAXLoadedHtmlPartial', (html) => {
        // SHOULD NOT USE THIS
        // ajax loaded partials should not load scripts

        // get first script tag's nonce from page (not ajax loaded part)
        const $scriptNonce = $('script[nonce]').first();
        // use first script tag's nonce is there is any, otherwise use meta tag's
        // might not be the cleanest solution, but we shouldn't be doing this at all so...
        const nonce = $scriptNonce.length > 0 ? $scriptNonce[0].nonce : getNonce();
        // inject proper nonce into html code
        const nonceInjectedHtml = injectNonce(html, nonce);

        $('#ajaxloadedhtml').html(nonceInjectedHtml);
    })
};

$(function () {
    console.log('ajaxloadedhtml.js loaded');

    initPage();
});