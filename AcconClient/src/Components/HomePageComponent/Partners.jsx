import React from 'react';
import SliderPartners from "@/Components/Slider/SliderPartners";

const Partners = () => {
    const partnersJson = [
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        },
        {
            url:"partner-1.png"
        }
    ]

   return <div className="container partners">
       <div className="headline">
           <h2>OUR PARTNERS</h2>
           <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
       </div>
       <SliderPartners data={partnersJson}/>
   </div>
};

export default Partners;
