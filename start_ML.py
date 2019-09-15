import numpy as np
import pandas as pd
import matplotlib.pyplot as pyplot

n_clusters=10
iterations=100

properties = ['a','b','c','d','e']

# a function calculating the nearest cluster
def nearest_cluster(coords):
    distances=[]
    for com in cluster:
        distances.append(np.sqrt(np.sum((coords-com)**2)))
    closest=np.argmin(distances, axis=1)
    distance=distances[closest]

    return closest

#remove all entries with empty properties
mask=[]
for prop in properties:
    mask=data[np.all([mask, type(i)!=str for i in data[prop]],axis=0)]
used_data=data[mask]

#rescale everything into a number between 0 and 1
for i in range(len(properties)):
    used_data[i]=(used_data[i]-np.min(used_data[i]))/(np.max(used_data[i])-np.min(used_data[i]))

#generate n random cluster centers
cluster=[]
for i in range(n_clusters):
    cluster.append(np.random.rand(len(properties)))

member_of=np.zeros(len(used_data))
for j in range(iterations):
    #calculate nearest cluster center for eacht datapoint
    for i in range(len(used_data)):
        member_of[i]=nearest_cluster(used_data[i])

    #calculate new cluster centers
    for i in range(n_clusters):
        cluster[i]=np.sum(used_data[member_of==i])/len(used_data[member_of==i])

for i in range(len(used_data)):
    SQL_commmand="UPDATE exoplanets_data SET cluster="+str(member_of[i])+" WHERE entryID="+ str(used_data[0][i]+";")
