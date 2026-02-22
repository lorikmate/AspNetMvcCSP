var jquery = $;

jquery.getScript = function (scriptUrl, nonce) {
    return new Promise((resolve, reject) => {
        const script = document.createElement('script');
        script.src = `${scriptUrl}?v=${Date.now()}`;
        script.async = true;
        script.nonce = nonce;

        script.onload = () => resolve();
        script.onerror = () => {
            reject(new Error("getScript error"));
        };

        document.head.appendChild(script);
    })
}