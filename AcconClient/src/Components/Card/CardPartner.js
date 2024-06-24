import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";

const CardPartner = ({data}) => {
    return (
       <LazyLoadImage src={data.url}/>
    );
};

export default CardPartner;
