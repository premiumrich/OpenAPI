package com.trulioo.sdk;

import java.util.Map;
import java.util.List;

public abstract class SuccessfulCallback<T> implements ApiCallback<T> {
    public void onFailure(ApiException e, int status, Map<String, List<String>> headers) {
    }

    public abstract void onSuccess(T resultAsync, int status, Map<String, List<String>> headers);

    public void onUploadProgress(long bytesWritten, long contentLength, boolean done) {
    }

    public void onDownloadProgress(long bytesRead, long contentLength, boolean done) {
    }
}
