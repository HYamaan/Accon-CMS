import React from 'react';
import CardPhotoGallery from "@/Components/Card/CardPhotoGallery";
import {photoJson} from "@/data/photoJson";
import "yet-another-react-lightbox/styles.css";
import "yet-another-react-lightbox/plugins/captions.css";
const PhotoGallery = ({galleries}) => {
return <>
       <div className="photo-gallery-section">
           <div className="container photo-gallery">
               <div className="headline">
                   <h2>{galleries.title}</h2>
                   <p>{galleries.subTitle}</p>
               </div>
               <div className="row">
                   {galleries?.gallery?.map((photo, index) => {
                       return <CardPhotoGallery key={index} data={photo}/>
                   })}
               </div>
           </div>
       </div>
   </>
};

export default PhotoGallery;
