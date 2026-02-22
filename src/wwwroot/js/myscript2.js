$(function () {
    console.log('myscript2.js loaded');
    const div = this.createElement("div");
    div.innerHTML = '<span style="color:blue;">MyScript2 Loaded</span>';
    document.body.appendChild(div);
});