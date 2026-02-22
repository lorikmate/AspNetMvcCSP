$(function () {
    console.log('myscript1.js loaded');
    const div = this.createElement("div");
    div.innerHTML = '<span style="color:red;">MyScript1 Loaded</span>';
    document.body.appendChild(div);
});