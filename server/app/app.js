'use strict';

// Importing npm modules.
const 
    express = require('express'),
    socket = require('socket.io'),
    os = require( 'os' ),
    fs = require('fs'),
    path = require('path');

//
//  SETUP
//

// Reading settings.json.
var settings = fs.readFileSync('./public/settings.json');
settings = JSON.parse(settings);
var port = settings.port;
var ip_v4 = ''

// Acquiring local wlan-ipv4 address.
var ifaces = os.networkInterfaces( );

Object.keys(ifaces).forEach(function (ifname) {
    var alias = 0;

    ifaces[ifname].forEach(function (iface) {
      if ('IPv4' !== iface.family || iface.internal !== false) {
        // skip over internal (i.e. 127.0.0.1) and non-ipv4 addresses
        return;
      }

      if (alias >= 1) {
        // this single interface has multiple ipv4 addresses
        console.log(ifname + ':' + alias, iface.address);
        ip_v4 = iface.address
      } else {
        // this interface has only one ipv4 adress
        console.log(ifname, iface.address);
        ip_v4 = iface.address
      }
      ++alias;
    });
  });

// Writing local wlan-ipv4 address to settings.json.
settings.wlan_ip = ip_v4;
fs.writeFileSync('./public/settings.json', JSON.stringify(settings), (err) => {});


// Initialising express object.
var app = express();

// Starting server on port, specified in json.
var server = app.listen(port, () => {
});

// Use 'public' directory as host.
app.use(express.static('public'));

var io = socket(server);

io.attach(4567);

io.sockets.on('connection', newConnection);

//
//  LOOPS
// 

var angles = {
  'beta': 0,
  'gamma': 0,
}

// Called when new client connection is made.
function newConnection(socket) {
  
  console.log("New Connection!");

  // Phone Client
  socket.on('position', posMsgHandler);

  // Unity Client
  socket.on('angleRequestMsg', function(){
		socket.emit('unityMsg', angles);
	});

  function posMsgHandler(data) {

    angles['beta'] = data['beta'];
    angles['gamma'] = data['gamma'];

    console.log(angles);
  }
}
