import React from 'react';
import {toast} from "react-toastify";

const OneFileUpload = ({ file, setFile, propsClass }) => {
    function handleMultipleChange(event) {
        const selectedFile = event.target.files[0]; // Directly access the first file

        if (selectedFile) { // Check if there's a file selected
            console.log("selectedFile", selectedFile);
            const allowedExtensions = ['.png', '.jpeg', '.jpg', '.svg'];
            const fileName = selectedFile.name.toLowerCase();

            const isValidFiles = allowedExtensions.some(ext => fileName.endsWith(ext));

            if (!isValidFiles) {
                toast.error('Dosya uzantıları .png, .jpeg, .jpg veya .svg olmalıdır.');
                event.target.value = ''; // Resetting the value of the input
            } else {
                setFile(selectedFile); // Update the state with the selected file
            }
        } else {
            console.log("No file selected.");
        }
    }

    return (
        <input
            type="file"
            onChange={handleMultipleChange}
            className={propsClass}
        />
    );
};

export default OneFileUpload;
