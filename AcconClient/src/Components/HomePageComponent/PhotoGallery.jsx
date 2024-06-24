import React from 'react';
import CardPhotoGallery from "@/Components/Card/CardPhotoGallery";
import {photoJson} from "@/data/photoJson";
import "yet-another-react-lightbox/styles.css";
import "yet-another-react-lightbox/plugins/captions.css";
const PhotoGallery = () => {
return <>
       <div className="photo-gallery-section">
           <div className="container photo-gallery">
               <div className="headline">
                   <h2>PHOTO GALLERY</h2>
                   <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
               </div>
               <div className="row">
                   {photoJson.map((photo, index) => {
                       return <CardPhotoGallery key={index} data={photo}/>
                   })}
               </div>
           </div>
       </div>
   </>
};

export default PhotoGallery;
