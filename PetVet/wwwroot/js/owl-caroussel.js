var next = document.getElementsByClassName('next');
var prev = document.getElementsByClassName('prev');
var product = document.getElementsByClassName('product')
let product_page = Math.ceil(product.length / 4);
var l = 0;



window.addEventListener('resize', redimensionar);
function redimensionar() {
    let mob_view = window.matchMedia("(max-width: 768px)");
    if (mob_view.matches) {
        movePer = 90;
        maxMove = 600;
    } else {
        movePer = 50;
        maxMove = 165;
    }
}
redimensionar();

function right_mover() {
    l = l + movePer;
    if (product == 1) { l = 0; }
    for (const i of product) {
        if (l > maxMove) { l = 0; }
        i.style.left = '-' + l + '%';
    }
}
function left_mover() {
    l = l - movePer;
    if (l <= 0) { l = 0; }
    for (const i of product) {
        if (product_page > 1) {
            i.style.left = '-' + l + '%';
        }
    }
}




