# Software Engineer Take-home Exercise

This is the starting point for software engineering interviews at [ClinkIT Solutions](https://www.clinkitsolutions.com).

## Instructions

You should have received an email with a link to this repo along with initial instructions including a deadline and an interview schedule.

For this exercise, we need you to:

1) Fork or clone this repo. You can choose to fork it and be public. If you prefer a private repository, clone the repo, publish it privately, and add engineering@clinkitsolutions.com to the repo so we can have access to review your work.

2) Add your changes. Try to put focus on the areas you are strong at. If you can prettify the UI or improve the user experience, do so. If you think the backend needs work and you can make those changes, go ahead. We want to see changes related to the problem below, but if you're feeling creative, go wild. Feeling a bit more React or Svelte-y? Re-write the UI! You think unit tests with 100% code coverage are mandatory? Write 'em. Clean code is the one true way of writing code? Refactor everything. The app has potential and you wanna prepare for the next 1M users and Series A funding? Perhaps design a new architecture? We just request that you keep the backend to .NET as this is our primary stack.

3) Update the readme with information about your changes and include instructions on how to run the projects. Ideally, it should be as simple as an ```npm install``` and ```npm start``` for the UI and a `dotnet run` for the backend. If you feel like putting the project up on an accessible server, you're more than welcome.

4) Reply to the initial instruction email with a link to your copy of the repo. Make sure to add our account if the copy is private.

## Background

This repo contains a theoretical work-in-progress app called Fleet that is used to keep track of vehicles. At any given time, one or more vehicle information is sent to the server by a number of clients. This information is logged and considered the latest information for that vehicle. If a vehicle is unknown, then a new entry is created for it. Vehicles are also part of zero or more fleets, which are basically just an arbitrary group or list of vehicles.

The UI consists of a real-time view with a map that shows the latest location of each vehicle along with additional information. The user can then filter the view by fleet.

The Fleet app is also expanding and will now be used to track all kinds of assets, from vehicles to work-issued equipment of varying frequency (real-time, end-of-day, once-every-n-hours), so it is expecting heavier traffic.

## Technical Requirements

There is a feature request to be able to manually upload a file containing historical information about assets. Each item contains a timestamp of when the information for that particular asset was logged, so it might not necessarily be the latest information for the asset.

Users should be able to browse uploaded files and view the assets' static location on the map as of that file. If the information in the file represents the latest details about an asset, then that should reflect in the real-time view.

There might also be a few bugs in the latest commit of the repo, and you should be able to fix that.

To summarize, here are the basic requirements, but as mentioned, you can be more creative, try to do everything, or focus on whatever you want:

1) A new endpoint that accepts a file (csv, json, whatever kind you want)
2) A new endpoint that returns a list of uploaded files
3) A new endpoint that returns the assets given a previously uploaded file
4) UI changes to support the requirements
5) Backend or database changes needed if any

Instructions for running the app can be found in the respective folders: [ui](ui) and [api](api).

If you have any questions about the exercise, don't hesitate to reply back to the initial instructions email.

# Additional Information

## Why a take-home exercise?

We believe that interviews are best conducted with tasks that closely resemble the day-to-day requirements of the job. This includes things like setting your machine up for new projects, getting familiar with an existing codebase, quickly learning a library or two, debugging, making small to medium changes to both frontend and backend code, dealing with storage, and improving what's already written.

How we assess you will be a combination of both actual output and the technical interview that follows.

## What do I need to prepare for the interview?

A working/running solution is ideal. You will be sending us a link to a copy of this repo with your changes. It would be great if we could run the projects in that copy so we can check out the changes ourselves. However, we will definitely be checking out your code and a large chunk of the interview will revolve around your output.

With regards to this exercise, we generally want to know your thought process surrounding the changes you've made. Did you understand the task well? What assumptions did you make? Why did you choose to use library XYZ? Are there better implementations of feature ABC? How did you find the exercise? What can we improve?

After that, we'll be conducting a more standard background/culture fit/technical interview.