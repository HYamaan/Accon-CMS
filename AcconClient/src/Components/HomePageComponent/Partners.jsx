import React from 'react';
import SliderPartners from "@/Components/Slider/SliderPartners";

const Partners = ({partners}) => {
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
           <h2>{partners.title}</h2>
           <p>{partners.subTitle}</p>
       </div>
       <SliderPartners data={partners.partners}/>
   </div>
};

export default Partners;
