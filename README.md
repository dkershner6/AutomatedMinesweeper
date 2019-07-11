# AutomatedMinesweeper
Coding challenge to explode as many mines as possible

//  EXERCISE  
//
// There are bunch of mines in a mine field, and you are tasked with
// exploding as many of them as you can.  The only caveat is you can
// only explode one manually.  The mine you manually explode will set
// off a chain reaction.  For any mine that explodes, all mines within
// the blast radius of that mine will be triggered to explode in one
// second.  The mine you manually explode blows up at time 0.

// Your Task: Write a program which will read in a mines file and
// output the maximum number of mines you can explode.  Also output 
// which mine you need to manually set off to explode this maximum 
// number.  Since there may be multiple mines that blow up a maximal 
// number of mines you should output all the mines that do that.

// We'll provide you with:

// Mines API Call (Json) with values:
//[{x: x, y: y, r: r}] - where x is x coordinate, y is y coordinate and r is blast radius

// Example:
// [{x: 1, y: 2, r: 53},
// {x: -32, y: 40, r: 100},
// {x: 10, y: 15, r: 25},
// {x: -15, y: -15, r: 200}]

// Formula to determine if a mine explodes another mine:
// class Exploder {
//   boolean mine_exploded?(Float x1, Float y1, Float r, Float x2, Float y2) {
//     return r <= Math.sqrt(Math.pow((x2-x1),2) + Math.pow((y2-y1),2))
//   }
// }