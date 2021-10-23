# CarControl
Remote control for your car
Before reading this I recommend you watch these videos on Esp32 and relays
https://youtu.be/giACxpN0cGc
https://youtu.be/-9D-vtZ-wl4
Supplies
4 channel 5v relay module £4 on ebay
ESP32 Development board £4 on Ebay from seller: moduleme in China
Wires (ensure they can handle the current)
Heat shrink
Huawei E5330-3Gl Mobile Wi-Fi £40
Pay as you go sim 1p per MB £10 credit
12v to 5v DC converter Ebay £2

Wiring the relays
First you should know each relay has 3 terminals:
NO - normally open (when the relay is off this terminal is not connected to COMMON)
COMMON
NC -normally closed (when the relay is off this terminal is connected to COMMON)

The information here describes how I connected one of the relays to the drivers side high beam. You can connect up other items e.g. horn, sidelights, fog lights, windscreen washer!

I obviously still wanted the light to work normally, so I connected the relay as follows:

Cut the positive wire going to the driver side high beam.
Extend both wires far enough to reach the fuse box.
Connect the wire from the light to the COMMON terminal on the relay.
Connect the other wire to the NC terminal. This effectively joins the wires back together and the lights will work as normal when the relay has no power.
Connect permanent live to the NO terminal. Now when the relay is powered, the COMMON terminal will connect to the NO terminal and the light will get power.

On my car, I connected the 4 relays as follows:
1 to low frequency horn
1 to sidelights
1 to left high beam
1 to right high beam.

You actually can control more than 4 relays with the ESP32, and you can get boards with 8 or 16 relays.

I have placed the Mobile Wi-Fi device in the centre console.

Programming the Esp32 for car control
GitHub bogbrush/ESP32CarControl

Creating the CarControl website
GitHub bogbrush/CarControl

    
