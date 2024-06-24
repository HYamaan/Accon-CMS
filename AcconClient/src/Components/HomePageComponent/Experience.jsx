import React from 'react';
import SliderTeam from "@/Components/Slider/SliderTeam";

const Experience = () => {

    const experienceJson = [
        {
            url:"team-member-1.jpg",
            name:"Robert Smith",
            position:"Chairman",
            linkedin:"https://www.linkedin.com/",
            twitter:"https://twitter.com/",
            facebook:"https://www.facebook.com/",
            youtube:"https://www.youtube.com/",
        },
        {
            url:"team-member-2.jpg",
            name:"Brent Grundy",
            position:"Manager",
            linkedin:"https://www.linkedin.com/",
            twitter:"https://twitter.com/",
            facebook:"https://www.facebook.com/",
            youtube:"https://www.youtube.com/",
        },
        {
            url:"team-member-3.jpg",
            name:"John Henderson",
            position:"Engineer",
            linkedin:"https://www.linkedin.com/",
            twitter:"https://twitter.com/",
            facebook:"https://www.facebook.com/",
            youtube:"https://www.youtube.com/",
        },
        {
            url:"team-member-4.jpg",
            name:"Patrick Joe",
            position:"Engineer",
            linkedin:"https://www.linkedin.com/",
            twitter:"https://twitter.com/",
            facebook:"https://www.facebook.com/",
            youtube:"https://www.youtube.com/",
        },
        {
            url:"team-member-5.jpg",
            name:"Peter Robertson",
            position:"Worker",
            linkedin:"https://www.linkedin.com/",
            twitter:"https://twitter.com/",
            facebook:"https://www.facebook.com/",
            youtube:"https://www.youtube.com/",
        },
    ]

    return <>
        <div className="experience-section">
            <div className="container experience">
                <div className="headline">
                    <h2>EXPERIENCED TEAM</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
                </div>
                <SliderTeam data={experienceJson}/>
            </div>
        </div>
    </>
};

export default Experience;
