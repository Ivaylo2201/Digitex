type AuthHeaders = {
    headers: {
        Authorization: string;
    };
};

export default function getAuthHeaders(): AuthHeaders {
    return {
        headers: {
            Authorization: `Token ${localStorage.getItem('token')}`
        }
    };
}
