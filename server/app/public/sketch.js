var socket;
var pos;

var settings = {};

var beta = 0;
var gamma = 0;
var alpha = 0;

function preload() {
    // Loading settings.json file
    settings = loadJSON('./settings.json');
}

function setup() {
    createCanvas(windowWidth, windowHeight);
    background(0);

    pos = createVector(width / 2, height / 2);

    socket = io.connect(`http://${settings['wlan_ip']}:${settings['port']}`);
}

function draw() {
    
    noStroke();
    background(0);
    fill(204, 101, 192, 255);
    ellipse(windowWidth*gamma/180+windowWidth/2, windowHeight*beta/180+windowWidth/2, 60, 60);
  
    var posData = {
        'beta': beta, // x
        'gamma': gamma, // y
    }

    socket.emit('position', posData);
}

function handleOrientation(event) {
    beta = event.beta;  // x In degree in the range [-180,180]
    gamma = event.gamma; // y In degree in the range [-90,90]
    alpha = event.alpha; // z In degree in the range [0, 360]
  }
  
window.addEventListener('deviceorientation', handleOrientation);
