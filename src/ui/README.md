# Fleet Frontend

This folder contains the frontend for the take-home exercise.

# Technical Details

The UI consists of a barebones Angular project built using Angular 13. To run the program, first, make sure you have the corresponding node.js and npm versions installed. Then navigate to the UI folder and run `npm install` and `npm start`.

There is a single component called `HomeComponent` which houses all the UI components: a map using [ngx-leaflet](https://github.com/Asymmetrik/ngx-leaflet), some elements housing the controls, and a loading spinner.

Additionally, the project uses [ng-openapi-gen](https://github.com/cyclosproject/ng-openapi-gen) to generate an API client against the swagger docs exposed by the backend. You may use this for your convenience. To update the API client, make sure that your API is running, the URL is properly configured in `openapi-gen.json`, and  run `npm run apigen`. Otherwise, you can write your own clients for whatever endpoints you need to communicate with.

# Task

For the frontend part of the exercise, you are to add file upload functionality that accepts files of your own format which should be sent to the backend. Then, you also need to list all of the files previously uploaded. When clicking a file, it should display the vehicles in their respective locations as contained in the file, in contrast to selecting from fleets which always displays a real-time view with their latest locations. Note, in the exercise, the project will now be used to handle all sorts of assets with location, not just vehicles.

You may choose to implement this however you like: use any UI libraries, rewrite the project in your framework of choice, redesign the layout or the controls, add additional properties to the assets such as an image of the last location, or whatever your imagination can produce.

You may choose to focus 100% of your energy on the UI, in which case, please write mock backends or datasources for your changes. You may go above and beyond the basic requirements to demonstrate in-depth technical knowledge and product design chops.
