import React, {useRef, useState} from 'react';

const OneFileUpload = ({file,setFile, propsClass}) => {
    function handleMultipleChange(event) {
        const selectedFile = event.target.files[0];
        console.log("selectedFile", selectedFile);
        const allowedExtensions = ['.png', '.jpeg', '.jpg', ".svg"];
        const fileName = selectedFile?.name.toLowerCase();
        const isValidFiles = allowedExtensions.some(ext => fileName.endsWith(ext));
        console.log("selectedFile", selectedFile)
        if (!isValidFiles) {
            alert('Dosya uzantıları .png, .jpeg veya .jpg olmalıdır.');
            event.target.value = null;
        } else {
            setFile(selectedFile);
        }
    }
    return <>
        <input
            type="file"
            onChange={handleMultipleChange}
            className={propsClass}
        />
    </>
};

export default OneFileUpload;
