import * as Yup from 'yup';

export const contactSchema=Yup.object({
    name: Yup.string().required('Name is required')
        .min(3, 'Name must be at least 3 characters'),
    email:Yup.string().email('Invalid email').required('Email is required'),
    phone:Yup.string().required('Phone is required').min(10, 'Phone must be at least 10 characters'),
    message:Yup.string().required('Message is required').min(10, 'Message must be at least 10 characters')
});
